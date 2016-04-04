using UnityEngine;
using System.Collections;

public class tossGrenade : MonoBehaviour {

	public GameObject obj;
	public Transform tossPoint;
	GameObject waffle;
	Rigidbody wrb;

	// Use this for initialization
	void Start () 
	{
		waffle = (GameObject)Instantiate(obj);
		waffle.GetComponent<newWaffleScript>().player = gameObject;
		waffle.SetActive (false);
		wrb = waffle.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			waffle.transform.position = tossPoint.position;
			waffle.transform.rotation = tossPoint.rotation;
			waffle.SetActive(true);
			wrb.AddRelativeForce(0, 0, 20, ForceMode.Impulse);
		}
	}
}
