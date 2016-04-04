using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class playerHealth : MonoBehaviour {

	public int health = 100;
	private CharacterController playerCon;
	private FirstPersonController playerFPS; 
	private Animator anim;
	private screenFlash flash;
	private FadeInFadeOut fade;

	void Start () {
		fade = GetComponentInChildren<FadeInFadeOut> ();
		flash = GetComponentInParent<screenFlash> ();
		playerCon = GetComponentInParent<CharacterController> ();
		playerFPS = GetComponentInParent<FirstPersonController> ();
		anim = GetComponentInParent<Animator> ();
		anim.enabled = false;
	}

	void Update () {
		if (health <= 0) {
			playerCon.enabled = false;
			playerFPS.enabled = false;
			flash.Dead ();
			anim.enabled = true;
			StartCoroutine("Deadtime");
			fade.isDead = true;

		}
	}

	public void TakeDamage(int attackDamage) {
		health -= attackDamage;
		flash.inPain = true;
	}

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 100, 20), "HEALTH: " + health + "");
	}

	IEnumerator Deadtime() {
		yield return new WaitForSeconds (3.0f);
		Application.LoadLevel(Application.loadedLevel);
	}
}
