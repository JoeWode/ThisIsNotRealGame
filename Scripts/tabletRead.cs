using UnityEngine;
using System.Collections;

public class tabletRead : MonoBehaviour {

	public Material matStart;
	public Material outline;
	private Renderer rend;
	public bool selected;
	public GameObject page;
	public GameObject player;
	public float tabDist;

	void Start () {
		rend = GetComponentInChildren<Renderer> ();
		rend.material = matStart;
		selected = false;
		page.SetActive (false);
	}

	void Update () {
		if (selected && Input.GetKey (KeyCode.X)) {
			page.SetActive (true);
		} else {
			page.SetActive (false);
		} 

		tabDist = Vector3.Distance (player.transform.position, transform.position);
		if (tabDist >= 2.0f) {
			selected = false;
			rend.material = matStart;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "damageDetection") {
			rend.material = outline;
			selected = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "damageDetection") {
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
