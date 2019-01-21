using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayObjectScript : MonoBehaviour {

	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = VoiceRecordScript.getAudioClip();
	}
	
	// Update is called once per frame
	void Update () {
		if(audioSource.clip != null) {
			Debug.Log("Find!");
			audioSource.Play();
		} else {
			Debug.Log("null");
		}
	}
}
