using UnityEngine;
using System.Collections;

public class holdCharacter : MonoBehaviour {

	public GameObject player;

	void OnTriggerEnter() {
		player.transform.parent = gameObject.transform;
	}

	void OnTriggerExit(Collider col) {
		player.transform.parent = null;
	}
}
