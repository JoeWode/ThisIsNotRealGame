using UnityEngine;
using System.Collections;

public class Level_control_cell01 : MonoBehaviour {

	public GameObject doorPanel;
	public GameObject tray;
	Animator doorAnim;
	Animator trayAnim;
	AudioSource open;
	AudioSource close;
	public bool playSound = false;

	void Start () {
		doorAnim = doorPanel.GetComponent<Animator> ();
		trayAnim = tray.GetComponent<Animator> ();
		open = doorPanel.GetComponent<AudioSource> ();
		close = GetComponent<AudioSource> ();
	}

	void Update () {
		if (readJournal.read01 && readJournalPage.read02) {
			doorAnim.SetBool ("panelOpen", true);
			if (tray != null) {
				trayAnim.SetBool ("slide", true);
			}
			readJournal.read01 = false;
			readJournalPage.read02 = false;
			if (open.enabled && close.enabled){
				open.PlayScheduled(AudioSettings.dspTime + 0.25f);
				close.PlayScheduled (AudioSettings.dspTime + 1.9f);
			}
			StartCoroutine ("SoundOff");
		}
	}

	IEnumerator SoundOff() {
		yield return new WaitForSeconds (3);
		open.enabled = false;
		close.enabled = false;
	}
}
