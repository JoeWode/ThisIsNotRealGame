using UnityEngine;
using System.Collections;

public class repeatAudio : MonoBehaviour {

	AudioSource audio;
	public float repeatSpeed = 10.0f;


	void Start () {
		audio = GetComponent<AudioSource> ();
		InvokeRepeating ("AudioRepeat", 10, repeatSpeed);
	}
	

	void AudioRepeat () {
		if (!AttackOn.isTargeted) {
			audio.Play ();
		}
	}
}
