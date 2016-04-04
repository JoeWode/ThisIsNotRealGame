using UnityEngine;
using System.Collections;

public class mouseOverOutline : MonoBehaviour {

	public Material matStart;
	public Material outline;
	private Renderer rend;
	private bool selected;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.material = matStart;
		selected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (selected && Input.GetKey (KeyCode.X)) {
			Destroy (gameObject, 0.5f);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "FPSController") {
			rend.material = outline;
			selected = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "FPSController") {
			rend.material = matStart;
			selected = false;
		}
	}

	void OnGUI() {
		if (selected) {
			GUI.Label (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 20, 200, 20), "Press 'X' to Eat This Almost Certainly Drugged Food.");
		}
	}
}
