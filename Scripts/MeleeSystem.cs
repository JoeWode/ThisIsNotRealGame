using UnityEngine;
using System.Collections;

public class MeleeSystem : MonoBehaviour {

	LineRenderer line;
	public GameObject sparks;
	AudioSource hitSound;

	void Start() {
		line = GetComponent<LineRenderer> ();
		line.enabled = false;
		hitSound = GetComponent<AudioSource> ();
	}

	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			StopCoroutine ("Swing");
			StartCoroutine ("Swing");
		}
	}

	IEnumerator Swing() {
		line.enabled = true;
		yield return new WaitForSeconds(0.2f);

		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;

		line.SetPosition (0, ray.origin);

		if (Physics.Raycast(ray, out hit, 2)) { 
			line.SetPosition(1, hit.point);
			if (hit.rigidbody) {
				hit.rigidbody.AddForceAtPosition(transform.forward * 1500, hit.point);
			}
		} 
		else 
			line.SetPosition (1, ray.GetPoint (2));

		if (hit.collider) {
			hit.collider.SendMessageUpwards("killRagdoll", SendMessageOptions.DontRequireReceiver);
			Instantiate(sparks, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
			hitSound.Play ();
		}
		yield return null;
		
		line.enabled = false;
	}
}
