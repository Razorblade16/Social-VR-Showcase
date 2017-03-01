using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    private GvrAudioSource audioSource;
    // Use this for initialization

    AudioClip clip;
    bool isPlaying = false;
	void Start () {
        audioSource = GetComponent<GvrAudioSource>();
        //clip = GetComponent<AudioSource>().clip;
	}

    void HitByRay() {
        if (isPlaying == false) {
            audioSource.Play();
            isPlaying = true;
        }
        
    }

    void Pause() {
        if (isPlaying) {
            audioSource.Pause();
            isPlaying = false;
        }
        
    }
}
