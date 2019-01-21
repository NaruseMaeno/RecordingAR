using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeControllerToRecScript : MonoBehaviour {

	private float fadeSpeed = 0.04f;
	private float red, blue, green, alfa;

	public bool flagFadeOut = false;
	public bool flagFadeIn = false;

	Image fadeImage;

	public static bool checker;

	// Use this for initialization
	void Start () {
		fadeImage = GetComponent<Image> ();
		red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;
		
		if(FadeControllerToHomeScript.Checking() == true) {
			fadeImage.enabled = true;
			alfa = 1;
			flagFadeIn = true;
		}
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
			checker = true;
			PlayerPrefs.SetInt("fadeImage_enable", 1);
			PlayerPrefs.SetInt("alfa", 1);
			SceneManager.LoadScene("RecordScene");
		}
	}

	void StartFadeIn() {
		alfa -= fadeSpeed;
		fadeImage.color = new Color(red, green, blue, alfa);
		if(alfa <= 0) {
			flagFadeIn = false;
			fadeImage.enabled = false;
			checker = false;
			PlayerPrefs.DeleteAll();
		}
	}

	public void PushButtonChangeSceneToRec() {
		flagFadeOut = true;
	}

	public static bool Checking() {
		return checker;
	}
}
