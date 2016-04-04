using UnityEngine;
using System.Collections;

public class platformRail : MonoBehaviour {

	public Transform[] pathObjs;
	public GameObject platform;
	//public GameObject lookTarget;
	public float pathPos = 1.0f;
	public float pathSpeed = 0.0005f;
	
	void FixedUpdate() {
		if (platform != null) {
			//platform.transform.LookAt (lookTarget.transform);
			//iTween.PutOnPath (lookTarget, pathObjs, pathPos + .01f);
			iTween.PutOnPath (platform, pathObjs, pathPos);
			pathPos -= pathSpeed;
		}
	}
	
	void OnDrawGizmos() {
		iTween.DrawPath (pathObjs);
	}
}
