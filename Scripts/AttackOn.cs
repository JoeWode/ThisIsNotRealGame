using UnityEngine;
using System.Collections;

public class AttackOn : MonoBehaviour {

	public GameObject onOff;
	public Transform playa;
	public int targetDistance = 17;
	public bool targeted = false;
	public static bool isTargeted = false;
	private SphereCollider attackSphere;
	
	void Start () {
		onOff.SetActive (false);
		attackSphere = onOff.GetComponent<SphereCollider> ();
		attackSphere.enabled = false;
	}

	void Update() {

		if (targeted && Vector3.Distance (transform.position, playa.position) <= targetDistance) {
			onOff.SetActive (true);
			attackSphere.enabled = true;
		} else if (targeted && Vector3.Distance (transform.position, playa.position) > targetDistance) {
			targeted = false;
			onOff.SetActive (false);
			attackSphere.enabled = false;
			isTargeted = false;
		} else {
			onOff.SetActive (false);
			attackSphere.enabled = false;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "damageDetection") {
			targeted = true;
			isTargeted = true;
		} 
	}

	void OntriggerExit(Collider other){
		if (other.gameObject.name == "damageDetection") {
			targeted = false;
			isTargeted = false;
		}
	}


}
