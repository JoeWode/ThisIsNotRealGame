using UnityEngine;
using System.Collections;

public class elevatorControl : MonoBehaviour {

	public GameObject shaft;
	private Animator shaftAnim;
	public bool activatable = false;

	// Use this for initialization
	void Start () {
		shaftAnim = shaft.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (activatable && Input.GetKeyUp (KeyCode.X)) {
			if(shaftAnim.GetBool("isActivated") == false) {
				shaftAnim.SetBool("isActivated", true);
			} else {
				shaftAnim.SetBool("isActivated", false);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "playa") {
			activatable = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "playa") {
			activatable = false;
		}
	}

	void OnGUI () {
		if (activatable) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 20), "Press 'X' to Activate");
		}
	}
}
