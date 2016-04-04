using UnityEngine;
using System.Collections;

public class FadeInFadeOut : MonoBehaviour {

	Renderer rend;
	private Material fadeMat;
	private Color fadeMatCol;
	private Color startCol;
	private Color transpCol;
	public float fadeSmooth = 2.5f;
	public bool isDead = false;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		fadeMat = rend.material;
		isDead = false;
		startCol = new Color (0, 0, 0, 255);
		fadeMatCol = new Color (0, 0, 0, 255);
		fadeMat.color = fadeMatCol;
		transpCol = new Color (0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead) {
			FadeIn ();
		} 
		if (isDead || Input.GetKey (KeyCode.V)) {
			FadeOut ();
		}
	}

	public void FadeIn() {
		fadeMatCol = Color.Lerp (fadeMatCol, transpCol, Time.deltaTime * fadeSmooth);
		fadeMat.color = fadeMatCol;
	}

	public void FadeOut() {
		fadeMatCol = Color.Lerp (fadeMatCol, startCol, Time.deltaTime * 0.002f);
		fadeMat.color = fadeMatCol;
	}
	
}
