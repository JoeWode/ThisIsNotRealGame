using UnityEngine;
using System.Collections;

public class teleLerp : MonoBehaviour {
	
	public GameObject player;
	public float teleSpeed = 1.0f;

	Rigidbody playerRB;
	
	
	void Start () 
	{
		playerRB = GetComponent<Rigidbody> ();
	}
	
	void Update() 
	{
		if (Input.GetKey(KeyCode.E)) 
		{
			Tele ();
		}
	}
	
	void Tele() 
	{
		
		playerRB.velocity = Vector3.zero;
		
		if (player.transform.position == transform.position) {
			gameObject.SetActive (false);
		} else {
			player.transform.position = Vector3.MoveTowards (player.transform.position, transform.position, Time.deltaTime);
		}
	}
}
