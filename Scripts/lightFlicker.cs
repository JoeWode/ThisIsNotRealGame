using UnityEngine;
using System.Collections;

public class lightFlicker : MonoBehaviour {

	public float minIntensity = 1.5f;
	public float maxIntensity = 8.0f;
	private Light light;
	private float random;
	public float flickerTime = 0.3f;


	void Start () {
		light = GetComponent<Light> ();
		InvokeRepeating ("Flicker", flickerTime, flickerTime);
	}

	void Flicker() {
		random = Random.Range (minIntensity, maxIntensity);
		light.intensity = random;
	}
}
