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

	VoiceRecordScript voiceRec;


	// Use this for initialization
	void Start () {
		seconds = 0f;
		minutes = 0;
		oldSeconds = 0f;
		
		voiceRec = GetComponent<VoiceRecordScript> ();
		uptext = gameObjectText.GetComponent<TextMesh>();

		uptext.text = "00:00 / " + (voiceRec.maxLengthSec / 60).ToString("00") + ":" + (voiceRec.maxLengthSec % 60).ToString("00");
	}
	
	// Update is called once per frame
	void Update () {
		if(voiceRec.recStart != true) {
			seconds = 0f;
			minutes = 0;
			oldSeconds= 0f;
			uptext.text = "00:00 / " + (voiceRec.maxLengthSec / 60).ToString("00") + ":"	+ (voiceRec.maxLengthSec % 60).ToString("00");
		} else {
			seconds += Time.deltaTime;

			if (seconds >= 60f) {
				minutes++;
				seconds -= 60;
			}

			if ((int)seconds != (int)oldSeconds) {

				uptext.text = minutes.ToString("00") + ":" + seconds.ToString("00") + " / " + (voiceRec.maxLengthSec / 60).ToString("00") + ":"	+ (voiceRec.maxLengthSec % 60).ToString("00");
			}
			oldSeconds = seconds;
		}
	}
}
