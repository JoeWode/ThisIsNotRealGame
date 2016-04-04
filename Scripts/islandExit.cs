using UnityEngine;
using System.Collections;

public class islandExit : MonoBehaviour {
	
	void OnTriggerEnter() {
		Application.LoadLevel ("menu");
	}

}
