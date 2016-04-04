using UnityEngine;
using System.Collections;

public class readJournal : MonoBehaviour {

	public Material matStart;
	public Material outline;
	private Renderer rend;
	public bool selected;
	public GameObject canvas;
	public static bool read01 = false;
	
	// Use this for initialization
	void Start () {
		rend = GetComponentInChildren<Renderer> ();
		rend.material = matStart;
		selected = false;
		canvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (selected && Input.GetKey (KeyCode.X)) {
			canvas.SetActive (true);
			read01 = true;
		} else {
			canvas.SetActive (false);
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
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 200, 20), "Hold 'X' to Read This.");
		}
	}
}
