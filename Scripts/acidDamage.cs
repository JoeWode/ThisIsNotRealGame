using UnityEngine;
using System.Collections;

public class acidDamage : MonoBehaviour {

	public bool submerged = false;
	public GameObject player;
	playerHealth ph;
	AudioSource acidDie;

	void Start () {
		ph = player.GetComponent<playerHealth> ();
		acidDie = GetComponent<AudioSource> ();
	}

	void Update () {
		if (submerged) {
			ph.TakeDamage (1);
		}
		if (ph.health == 0 && submerged) {
			acidDie.Play ();
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "damageDetection") { 
			submerged = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "damageDetection") { 
			submerged = false;
		}
	}

}
