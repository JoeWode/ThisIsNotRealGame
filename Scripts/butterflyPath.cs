using UnityEngine;
using System.Collections;

public class butterflyPath : MonoBehaviour {

	public Transform[] pathObjs;
	public GameObject target;
	public GameObject lookTarget;
	public float pathPos = 1.0f;
	public float pathSpeed = 0.0005f;
	
	void FixedUpdate() {
		if (target != null) {
			target.transform.LookAt (lookTarget.transform);
			iTween.PutOnPath (lookTarget, pathObjs, pathPos + .01f);
			iTween.PutOnPath (target, pathObjs, pathPos);
			pathPos -= pathSpeed;
		}
	}
	
	void OnDrawGizmos() {
		iTween.DrawPath (pathObjs);
	}
}
