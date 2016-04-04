using UnityEngine;
using System.Collections;

public class crosshair : MonoBehaviour {

	public Texture2D cross;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label (new Rect (Screen.width * .5f - 20, Screen.height *.5f - 30 , 50, 50), cross);
	}
}
