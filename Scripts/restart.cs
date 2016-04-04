using UnityEngine;
using System.Collections;

public class restart : MonoBehaviour {
	
	public void DoOver() {
		Application.LoadLevel (Application.loadedLevel);
	}
}
