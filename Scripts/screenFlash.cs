using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class screenFlash : MonoBehaviour {

	private ColorCorrectionRamp ramp;

	private VignetteAndChromaticAberration vig;

	private ScreenOverlay overLay;
	private float currentOverlay;
	public float minOverlay = 0.0f;
	public float maxOverlay = 10;
	public float overlayTime = 5.0f;

	private ColorCorrectionCurves flash; 
	private float currentSat;
	public float minFlash = 1.0f;
	public float maxFlash = 5.0f;
	public float flashTime = 10.0f;

	public bool inPain = false;

	public float shakeStrength = 0.25f;
	public float shake = 0.0f;
	
	Vector3 originalPosition;

	// Use this for initialization
	void Start () {
		ramp = GetComponent<ColorCorrectionRamp> ();
		ramp.enabled = false;
		vig = GetComponent<VignetteAndChromaticAberration> ();
		vig.enabled = false;
		overLay = GetComponent<ScreenOverlay> ();
		currentOverlay = overLay.intensity;
		flash = GetComponent<ColorCorrectionCurves> ();
		currentSat = flash.saturation;
		inPain = false;
		originalPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		Pain ();
		Shake ();
		inPain = false;
	}

	public void Pain() {
		if (inPain) {
			currentSat = Mathf.Lerp (currentSat, maxFlash, Time.deltaTime * flashTime);
			flash.saturation = currentSat;
			currentOverlay = Mathf.Lerp (currentOverlay, maxOverlay, Time.deltaTime * overlayTime);
			overLay.intensity = currentOverlay;
			vig.enabled = true;
		} else {
			currentSat = Mathf.Lerp(currentSat, minFlash, Time.deltaTime * flashTime); 
			flash.saturation = currentSat;
			currentOverlay = Mathf.Lerp (currentOverlay, minOverlay, Time.deltaTime * overlayTime);
			overLay.intensity = currentOverlay;
			vig.enabled = false;
		}
	}

	public void Dead() {
		ramp.enabled = true;
	}

	void Shake() {
		if(inPain)
		{
			shake = shakeStrength;
		}
		
		Camera.main.transform.localPosition = originalPosition + (Random.insideUnitSphere * shake);
		
		shake = Mathf.MoveTowards(shake, 0, Time.deltaTime * shakeStrength);
		
		if(shake == 0)
		{
			Camera.main.transform.localPosition = originalPosition;
		}
	}
}
