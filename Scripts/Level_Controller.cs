using UnityEngine;
using System.Collections;

public class Level_Controller : MonoBehaviour {

	public GameObject[] transmitters;
	public GameObject shield;

	// Use this for initialization
	void Start () {
		shield.SetActive (true);
		transmitters = GameObject.FindGameObjectsWithTag ("transmitter");
	}
	
	// Update is called once per frame
	void Update () {
		transmitters = GameObject.FindGameObjectsWithTag ("transmitter");
		if (transmitters.Length == 0) {
			shield.SetActive (false);
		}
	}
}
