using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceRecordScript : MonoBehaviour {
	
	AudioSource audioRecSource;
	AudioSource audioPlaySource;
	public int maxLengthSec = 5;
	public int frequency = 44100;

	private string micName = "";

	[System.NonSerialized]
	public bool recStart;
	[System.NonSerialized]
	public bool playStart;

	TimerCountUpScript countUp;

	// Use this for initialization
	void Start () {
		foreach(string device in Microphone.devices) {
			Debug.Log("Name= " + device);
			micName = device;
		}
		
		audioRecSource = GetComponent<AudioSource>();
		audioPlaySource = GetComponent<AudioSource>();

		countUp = GetComponent<TimerCountUpScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(countUp.minutes * 60 + countUp.seconds >= maxLengthSec) {
			recStart = false;
		}
	}

	public void RecStart () {
		Debug.Log("Rec Start.");
		audioRecSource.clip = Microphone.Start(micName, false, maxLengthSec, frequency);

		recStart = true;
	}

	public void RecEnd () {
		if(Microphone.IsRecording(micName) == true){
			Microphone.End(micName);
			Debug.Log("Recoding Finish.");
		} else {
			Debug.Log("Not Recoding Now.");
		}

		recStart = false;
	}

	public void RecPlay () {
		Debug.Log("Rec Play.");
		audioPlaySource = gameObject.GetComponent<AudioSource>();
		audioPlaySource.clip = audioRecSource.clip;
		audioPlaySource.Play();
		playStart = true;
	}
}
