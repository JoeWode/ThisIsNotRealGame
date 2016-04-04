using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenu;
	public static bool paused = false;
	public GameObject player;
	private FirstPersonController playerCon;

	// Use this for initialization
	void Start () {
		pauseMenu.SetActive (false);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		playerCon = player.GetComponent<FirstPersonController> ();
		playerCon.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Cancel")) {
			if (!paused) {
				paused = true;
			} else {
				paused = false;
			}
		}

		if (paused) {
			TimeStop ();
			pauseMenu.SetActive (true);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			playerCon.enabled = false;
		} else {
			TimeStop ();
			pauseMenu.SetActive (false);
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			playerCon.enabled = true;
		}
	}

	public static void TimeStop() {
		if (paused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
	
}
