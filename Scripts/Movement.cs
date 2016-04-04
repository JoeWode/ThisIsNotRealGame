using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	public float moveSpeed = 3.0f;
	public float rotateSpeed = 180.0f;
	public float jumpSpeed = 5.0f;
	public float gravity = 9.8f;
	CharacterController controller;
	Vector3 currentMovement;


	void Start () {
		controller = GetComponent<CharacterController> ();
	
	}

	void Update () {
		Move ();
	}
	
	void Move () {
		transform.Rotate (0, Input.GetAxis ("Mouse X") * rotateSpeed * Time.deltaTime, 0);
		transform.Translate (Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);
		
		currentMovement = new Vector3 (0, currentMovement.y, Input.GetAxis ("Vertical") * moveSpeed);
		currentMovement = transform.rotation * currentMovement;
		
		if (!controller.isGrounded) 
			currentMovement -= new Vector3 (0, gravity * Time.deltaTime, 0);
		else
			currentMovement.y = 0;
		
		if (controller.isGrounded && Input.GetAxis("Jump") != 0)
			currentMovement.y = jumpSpeed;

		if (!controller.isGrounded && Input.GetKey (KeyCode.F)) {
			gravity = .5f;
		} else {
			gravity = 9.8f;
		}
		
		
		controller.Move (currentMovement * Time.deltaTime);
	}
}
