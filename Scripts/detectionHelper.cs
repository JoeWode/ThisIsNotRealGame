using UnityEngine;
using System.Collections;

public class detectionHelper : MonoBehaviour {

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
		rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
	}
}
