using UnityEngine;
using System.Collections;

public class swingController : MonoBehaviour {

	Animator anim;
	AudioSource swing;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		swing = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown ("Fire1")) {
			anim.SetBool ("isSwinging", true);
			swing.Play ();
		} else {
			anim.SetBool ("isSwinging", false);
		}
	}
}
