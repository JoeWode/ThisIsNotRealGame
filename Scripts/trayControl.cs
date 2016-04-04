using UnityEngine;
using System.Collections;

public class trayControl : MonoBehaviour {

	public Material matStart;
	public Material outline;
	private Renderer rend;
	private bool selected;
	public GameObject tray;
	public static bool drugged = false;
	BoxCollider bCol;
	AudioSource eat;

	void Start () {
		rend = GetComponentInChildren<Renderer> ();
		rend.material = matStart;
		selected = false;
		bCol = GetComponent<BoxCollider> ();
		eat = GetComponent<AudioSource> ();
	}

	void Update () {
		if (selected && Input.GetKey (KeyCode.X)) {
			drugged = true;
			eat.Play ();
			Destroy (tray, 0.25f);
			bCol.enabled = false;
			StartCoroutine("LevelLoad");
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
		if (selected && !drugged) {
			GUI.Label (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 20, 200, 20), "Press 'X' to Eat This.");
		}
	}

	IEnumerator LevelLoad() {
		yield return new WaitForSeconds (20);
		Application.LoadLevel (2);
	}
}
