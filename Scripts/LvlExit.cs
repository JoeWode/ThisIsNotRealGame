using UnityEngine;
using System.Collections;

public class LvlExit : MonoBehaviour {

	void OnTriggerEnter() {
		Application.LoadLevel ("scene_02");
	}
}
