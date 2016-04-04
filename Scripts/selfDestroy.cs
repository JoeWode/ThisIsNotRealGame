using UnityEngine;
using System.Collections;

public class selfDestroy : MonoBehaviour {

	public float destroyTime = 1.0f;
		
	void Update () {
		Destroy (gameObject, destroyTime);
	}
}
