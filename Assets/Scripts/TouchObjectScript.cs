using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObjectScript : MonoBehaviour {

	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = VoiceRecordScript.getAudioClip();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);

			if(touch.phase == TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit hit = new RaycastHit();

				if(Physics.Raycast(ray, out hit)) {
					if(hit.collider.gameObject == this.gameObject){
						if(audioSource.clip != null) {
							audioSource.Play();
						} 
					}
				}
			}
		}
	}
}
