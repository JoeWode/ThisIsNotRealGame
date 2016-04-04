using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {

	LineRenderer line;
	Light fLight;
	ParticleSystem flash;
	public GameObject sparks;
	AudioSource buzz;

	void Start () {
		line = GetComponent<LineRenderer> ();
		line.enabled = false;
		fLight = GetComponent<Light> ();
		fLight.enabled = false;
		flash = GetComponent<ParticleSystem> ();
		flash.enableEmission = false;
		buzz = GetComponent<AudioSource> ();
	}
	

	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			StopCoroutine ("FireLaser");
			StartCoroutine ("FireLaser");
			buzz.Play ();
		} 
		if (Input.GetButtonUp ("Fire1") && buzz.isPlaying) {
			buzz.Stop ();
		}
	}

	IEnumerator FireLaser() {
		line.enabled = true;
		fLight.enabled = true;
		flash.enableEmission = true;


		while (Input.GetButton ("Fire1")) {

			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;

			line.SetPosition (0, ray.origin);

			if (Physics.Raycast(ray, out hit, 100)) {
			    line.SetPosition(1, hit.point);
				if (hit.rigidbody) {
					hit.rigidbody.AddForceAtPosition(transform.forward * 750, hit.point);
				}
			}
			else 
				line.SetPosition (1, ray.GetPoint (100));

			if (hit.collider) {
				hit.collider.SendMessageUpwards("killRagdoll", SendMessageOptions.DontRequireReceiver);
				Instantiate(sparks, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
			}
			

			yield return null;
		}
		line.enabled = false;
		fLight.enabled = false;
		flash.enableEmission = false;
	}

}
