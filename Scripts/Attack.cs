using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public int attackDamage = 1;
	public GameObject player;
	private playerHealth playerHealth;
	public bool attack;
	public float fireRate = 0.5F;
	private float nextFire = 0.0F;
	public GameObject fire1;
	public GameObject fire2;
	private ParticleSystem fire1Particles;
	private ParticleSystem fire2Particles;
	private Animator anim;
	private AudioSource shot;


	// Use this for initialization
	void Start () {
		shot = GetComponent<AudioSource> ();
		anim = GetComponentInParent<Animator> ();
		anim.enabled = false;
		playerHealth = player.GetComponent<playerHealth> ();
		fire1Particles = fire1.GetComponent<ParticleSystem> ();
		fire2Particles = fire2.GetComponent<ParticleSystem> ();
		attack = false;
		fire1Particles.enableEmission = false;
		fire2Particles.enableEmission = false;

	}

	void Update () {
		if (attack && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			AttackPlayer ();
		} else {
			fire1Particles.enableEmission = false;
			fire2Particles.enableEmission = false;
		}
	}

	void AttackPlayer() {
		playerHealth.TakeDamage(attackDamage);
		fire1Particles.enableEmission = true;
		fire2Particles.enableEmission = true;
		anim.enabled = true;
		shot.Play ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "damageDetection") {
			attack = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "damageDetection") {
			attack = false;
		}
	}
}
