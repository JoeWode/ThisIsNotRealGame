using UnityEngine;
using System.Collections;

public class ragdoll : MonoBehaviour {
	
	
	public Component[] bones;
	public Animator anim;
	public bool isDead;
	
	
	// Use this for initialization
	void Start () {
		
		bones = gameObject.GetComponentsInChildren<Rigidbody> (); 
		anim = GetComponent<Animator> ();
		nonRagdoll ();
		
	}
	void Update ()
		
	{
		//if (isDead) {
			//killRagdoll ();
		//} else {
			//nonRagdoll();
		//}
		
	}

	void nonRagdoll() {
		foreach (Rigidbody ragdoll in bones) {
			ragdoll.isKinematic = true;
		}
	}

	// Update is called once per frame
	void killRagdoll () 
	{
		foreach (Rigidbody ragdoll in bones)
		{
			ragdoll.isKinematic = false;
			ragdoll.AddExplosionForce(1000, transform.position, 1.0f, 1.0f);
			ragdoll.AddForceAtPosition (transform.up * 100, transform.position);
		}
		
		anim.enabled = false;
	}


}