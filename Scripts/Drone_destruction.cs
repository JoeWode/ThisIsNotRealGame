using UnityEngine;
using System.Collections;

public class Drone_destruction : MonoBehaviour {

	public GameObject replacement;
	public GameObject explosion;
	
	void Destroyed () {
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
		Instantiate (replacement, transform.position, transform.rotation);
		Rigidbody[] chunks = replacement.GetComponentsInChildren<Rigidbody> ();
		foreach (Rigidbody chunk in chunks) {
			chunk.AddExplosionForce(1000, transform.position, 1.0f, 1.0f);
		}

	}
}
