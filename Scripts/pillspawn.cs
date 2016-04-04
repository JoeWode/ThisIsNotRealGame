using UnityEngine;
using System.Collections;

public class pillspawn : MonoBehaviour {

	public GameObject pills;
	public bool spawning = false;

	void Update () {
		if (!spawning) {
			InvokeRepeating ("PillSpawn", 2, 3.0f);
			spawning = true;
		}
	}

	void PillSpawn() {
		Instantiate (pills, transform.position, transform.rotation);
	}
}
