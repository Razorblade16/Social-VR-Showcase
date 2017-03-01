using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayer : MonoBehaviour {

    public MediaPlayerCtrl scrMedia;

    bool isPlaying = false;

    void HitByRay() {
        if (isPlaying == false) {
            scrMedia.Play();
            isPlaying = true;
        }
        
    }

    void Pause() {
        if (isPlaying) {
            scrMedia.Pause();
            isPlaying = false;
        }
       
    }
}
