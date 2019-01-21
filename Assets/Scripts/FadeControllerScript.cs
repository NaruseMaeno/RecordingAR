using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeControllerScript : MonoBehaviour {

	private float fadeSpeed = 0.04f;
	private float red, blue, green, alfa;

	public bool flagFadeOut = false;
	public bool flagFadeIn = false;

	Image fadeImage;

	// Use this for initialization
	void Start () {
		fadeImage = GetComponent<Image> ();
		red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;
	}
	
	// Update is called once per frame
	void Update () {
		if(flagFadeOut == true) {
			StartFadeOut();
		}

		if(flagFadeIn == true) {
			StartFadeIn();
		}
	}

	void StartFadeOut() {
		fadeImage.enabled = true;
		alfa += fadeSpeed;
		fadeImage.color = new Color(red, green, blue, alfa);

		if(alfa >= 1) {
			flagFadeOut = false;
		}
	}

	void StartFadeIn() {
		alfa -= fadeSpeed;
		fadeImage.color = new Color(red, green, blue, alfa);
		if(alfa <= 0) {
			flagFadeIn = false;
			fadeImage.enabled = false;
		}
	}
}
