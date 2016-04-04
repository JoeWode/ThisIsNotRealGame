using UnityEngine;
using System.Collections;

public class DKFire : MonoBehaviour {

	public GameObject muzzleFlash;
	Animator anim;
	ParticleSystem flash;
	AudioSource shot;

	// Use this for initialization
	void Start () {
		shot = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		flash = muzzleFlash.GetComponent<ParticleSystem> ();
		flash.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			StopCoroutine ("Fire");
			StartCoroutine ("Fire");
		} else {
			flash.enableEmission = false;
		}
	}

	IEnumerator Fire() {
		if (Input.GetButtonDown ("Fire1")) {
			flash.enableEmission = true;
			anim.SetTrigger ("Shoot");
			shot.Play();
		} else {
			flash.enableEmission = false;
		}
		yield return null;
	}
}
