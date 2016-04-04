using UnityEngine;
using System.Collections;

public class path : MonoBehaviour {

	public Transform[] pathObjs;
	public GameObject target;
	public GameObject lookTarget;
	public float pathPos = 1.0f;

	void Update() {
		target.transform.LookAt (lookTarget.transform);
		iTween.PutOnPath (lookTarget, pathObjs, pathPos - .01f);
		iTween.PutOnPath (target, pathObjs, pathPos);
		pathPos -= 0.001f;
	}

	void OnDrawGizmos() {
		iTween.DrawPath (pathObjs);
	}
}
