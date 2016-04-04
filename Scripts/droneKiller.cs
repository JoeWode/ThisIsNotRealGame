using UnityEngine;
using System.Collections;

public class droneKiller : MonoBehaviour {

	LineRenderer line;
	public GameObject sparks;
	public float force = 100.0f;
	public float radius = 2.0f;
	public float upwardsModifier = 2.0f;
	public ForceMode forceMode;



	void Start () {
		line = GetComponent<LineRenderer> ();
		line.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			StopCoroutine("FireDK");
			StartCoroutine ("FireDK");
		}
	}

	IEnumerator FireDK() {
		line.enabled = true;
		
		while (Input.GetButtonDown ("Fire1")) {
			
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;


			line.SetPosition (0, ray.origin);
			
			if (Physics.Raycast(ray, out hit, 100)) {
				line.SetPosition(1, hit.point);
				if (hit.collider) {
					Collider[] colliders = Physics.OverlapSphere(hit.point, radius);
					foreach(Collider col in colliders) {
						Rigidbody rb = col.GetComponent<Rigidbody>();
						
						if (rb != null)
							rb.AddExplosionForce(force, hit.point, radius, upwardsModifier, forceMode);
					}
				}
			}
			else 
				line.SetPosition (1, ray.GetPoint (100));
			
			if (hit.collider) {
				Instantiate(sparks, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
				hit.collider.SendMessageUpwards ("killRagdoll", SendMessageOptions.DontRequireReceiver);
				hit.collider.SendMessageUpwards ("Destroyed", SendMessageOptions.DontRequireReceiver);
			}
			
			yield return null;
		}
		line.enabled = false;

	}
}
