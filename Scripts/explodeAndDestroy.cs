using UnityEngine;
using System.Collections;

public class explodeAndDestroy : MonoBehaviour {

	public GameObject explosion;
	private float random;

	void Start() {
		random = Random.Range (1.0f, 3.0f);
	}
	
	void Update () {
		Destroy (gameObject, random);
		StartCoroutine ("Explode");

	}

	IEnumerator Explode() {
		yield return new WaitForSeconds (random - 0.1f);
		Instantiate (explosion, transform.position, transform.rotation);
	}
}
