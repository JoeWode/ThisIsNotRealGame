using UnityEngine;
using System.Collections;

public class audioDelay : MonoBehaviour {

	AudioSource audio;
	public float audioWaitTime = 5.0f;

	void Start () {
		audio = GetComponent<AudioSource> ();
		audio.PlayScheduled (AudioSettings.dspTime + audioWaitTime);
	}
}
