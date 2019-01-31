using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCountUpScript : MonoBehaviour {
	
	private TextMesh uptext;
	public GameObject gameObjectText;

	[System.NonSerialized]
	public float seconds;
	[System.NonSerialized]
	public int minutes;
	private float oldSeconds;

	[System.NonSerialized]
	public static int finishMinutes;
	[System.NonSerialized]
	public static float finishSeconds;

	VoiceRecordScript voiceRec;


	// Use this for initialization
	void Start () {
		seconds = 0f;
		minutes = 0;
		oldSeconds = 0f;
		
		voiceRec = GetComponent<VoiceRecordScript> ();
		uptext = gameObjectText.GetComponent<TextMesh>();

		uptext.text = "00:00.0 / " + (voiceRec.maxLengthSec / 60).ToString("00") + ":" + (voiceRec.maxLengthSec % 60).ToString("00.0");
	}
	
	// Update is called once per frame
	void Update () {
		if(voiceRec.recStart) {
			seconds += Time.deltaTime;

			if (seconds >= 60f) {
				minutes++;
				seconds -= 60;
			}

			if (seconds != oldSeconds) {
				uptext.text = minutes.ToString("00") + ":" + seconds.ToString("00.0") + " / " + (voiceRec.maxLengthSec / 60).ToString("00") + ":"	+ (voiceRec.maxLengthSec % 60).ToString("00.0");
			}
			finishMinutes = minutes;
			finishSeconds = seconds;
			oldSeconds = seconds;
		} else {
			seconds = 0f;
			minutes = 0;
			oldSeconds= 0f;
			uptext.text = "00:00.0 / " + (voiceRec.maxLengthSec / 60).ToString("00") + ":"	+ (voiceRec.maxLengthSec % 60).ToString("00.0");
		}
	}

	public static int FinishMinutes () {
		return finishMinutes;
	}

	public static float FinishSeconds () {
		return finishSeconds;
	}
}
