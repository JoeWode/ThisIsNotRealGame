using UnityEngine;
using System.Collections;

public class playSound : MonoBehaviour {

	public static AudioSource sound;
	
	void Start () {
		sound = GetComponent<AudioSource> ();
	}
	
	public static void SoundPlay() {
		sound.PlayScheduled (AudioSettings.dspTime + 0.5f);
	}
}
