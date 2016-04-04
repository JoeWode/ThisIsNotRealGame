using UnityEngine;
using System.Collections;

public class elevatorMove : MonoBehaviour {

	Animator anim;
	
	void Start () {
		anim = GetComponentInParent<Animator> ();
	}
	
	void OnTriggerEnter() {
		anim.SetBool ("elevatorMove", true);
	}
}
