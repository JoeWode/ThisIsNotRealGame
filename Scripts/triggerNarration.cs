using UnityEngine;
using System.Collections;

public class triggerNarration : MonoBehaviour {

	AudioSource narration;

	void Start () {
		narration = GetComponent<AudioSource> ();
		narration.enabled = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "damageDetection") {
			narration.enabled = true;
		}
	}
}
