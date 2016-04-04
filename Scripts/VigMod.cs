using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class VigMod : MonoBehaviour {

	private VignetteAndChromaticAberration vig;
	public float vigMin = -6.0f;
	public float vigMax = 6.0f;
	public float vigSpeed = 1.0f;
	public float currentVig;
	public bool rising = false;



	void Start () {
		vig = GetComponent<VignetteAndChromaticAberration> ();
		vig.enabled = false;
		currentVig = vig.chromaticAberration;
	}
	

	void Update () {
		if (trayControl.drugged) {
			vig.enabled = true;
			StartCoroutine ("Switch");
			if (rising) {
				currentVig = Mathf.Lerp (currentVig, vigMax, Time.deltaTime * vigSpeed);
				vig.chromaticAberration = currentVig;
			}
			if (!rising) {
				currentVig = Mathf.Lerp (currentVig, vigMin, Time.deltaTime * vigSpeed);
				vig.chromaticAberration = currentVig;
			}
		}
	}

	IEnumerator Switch() {
		if (!rising) {
			yield return new WaitForSeconds (4.0f);
			rising = true;
		} else {
			yield return new WaitForSeconds (4.0f);
			rising = false;
		}
	}
}
