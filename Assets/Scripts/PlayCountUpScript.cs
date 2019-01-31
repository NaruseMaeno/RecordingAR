using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCountUpScript : MonoBehaviour {

	private TextMesh downtext;
	public GameObject gameObjectText;

	private int minutes;
	private float seconds;
	private float oldCountUpSeconds;
	private int oldCountUpMinutes;
	private float oldSeconds;
	
	VoiceRecordScript voiceRec;

	// Use this for initialization
	void Start () {
		seconds = 0f;
		minutes = 0;
		oldSeconds = 0f;
		oldCountUpSeconds = 0f;
		oldCountUpMinutes = 0;
		
		voiceRec = GetComponent<VoiceRecordScript> ();
		downtext = gameObjectText.GetComponent<TextMesh>();

		downtext.text = "00:00.0 / 00:00.0";
	}
	
	// Update is called once per frame
	void Update () {
		if (!voiceRec.recStart) {
			if(TimerCountUpScript.FinishMinutes() != oldCountUpMinutes ||  TimerCountUpScript.FinishSeconds().ToString() != oldCountUpSeconds.ToString()) {
				downtext.text = minutes.ToString("00") + ":" + seconds.ToString("00.0") + " / " + TimerCountUpScript.FinishMinutes().ToString("00") + ":" + TimerCountUpScript.FinishSeconds().ToString("00.0");
				oldCountUpSeconds = TimerCountUpScript.FinishSeconds();
				oldCountUpMinutes = TimerCountUpScript.FinishMinutes();
			}

			if(voiceRec.playStart == true) {
				seconds += Time.deltaTime;

				if (seconds >= 60f) {
					minutes++;
					seconds -= 60;
				}

				if(seconds != oldSeconds) {
					downtext.text = minutes.ToString("00") + ":" + seconds.ToString("00.0") + " / " + TimerCountUpScript.FinishMinutes().ToString("00") + ":" + TimerCountUpScript.FinishSeconds().ToString("00.0");
				}
				oldSeconds = seconds;

				if(minutes.ToString("00") == TimerCountUpScript.FinishMinutes().ToString("00") && seconds.ToString("00.0") == TimerCountUpScript.FinishSeconds().ToString("00.0")) {
					downtext.text = minutes.ToString("00") + ":" + seconds.ToString("00.0") + " / " + TimerCountUpScript.FinishMinutes().ToString("00") + ":" + TimerCountUpScript.FinishSeconds().ToString("00.0");
					minutes = 0;
					seconds = 0f;
					oldSeconds = 0f;
					voiceRec.playStart = false;
				}
			}
		}
	}
}
