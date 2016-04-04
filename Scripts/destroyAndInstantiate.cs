using UnityEngine;
using System.Collections;

public class destroyAndInstantiate : MonoBehaviour {

	public GameObject[] newObjects;
	
	void OnCollisionStay (Collision col) {
		Destroy (gameObject);
		foreach (GameObject obj in newObjects){
			Instantiate (obj, transform.position, transform.rotation);
		}
		playSound.SoundPlay ();
	}
}
