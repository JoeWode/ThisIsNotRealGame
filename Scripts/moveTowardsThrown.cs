using UnityEngine;
using System.Collections;

public class moveTowardsThrown : MonoBehaviour {

	public GameObject obj;
	public Transform tosspoint;
	public float teleSpeed = 1.0f;
	GameObject thrownObj;
	Rigidbody thrownRB;

	// Use this for initialization
	void Start () {
		thrownObj = (GameObject)Instantiate (obj);
		thrownObj.SetActive (false);
		thrownRB = thrownObj.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Z)) {
			Throw ();
		}
		if (Input.GetKey (KeyCode.X)) {
			Tele ();
		}
	}

	void Throw () {
		thrownObj.transform.position = transform.position;
		thrownObj.transform.rotation = transform.rotation;
		thrownObj.SetActive(true);
		thrownRB.AddRelativeForce(0, 0, 20, ForceMode.Impulse);
	}

	void Tele () {
		thrownRB.velocity = Vector3.zero;
		transform.position = Vector3.MoveTowards (transform.position, thrownObj.transform.position, teleSpeed * Time.deltaTime);
		if (transform.position == thrownObj.transform.position) {
			thrownObj.SetActive (false);
		}
	}
}
