using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    private GvrAudioSource audioSource;
    // Use this for initialization

    AudioClip clip;
	void Start () {
        audioSource = GetComponent<GvrAudioSource>();
        clip = GetComponent<GvrAudioSource>().clip;
	}

    void HitByRay() {
        audioSource.Play();
    }

    void Pause() {
        audioSource.Pause();
    }
}
