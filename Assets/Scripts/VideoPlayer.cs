using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayer : MonoBehaviour {

    public MediaPlayerCtrl scrMedia;

    void HitByRay() {
        scrMedia.Play();
    }

    void Pause() {
        scrMedia.Pause();
    }
}
