using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoControl : MonoBehaviour {

    public MediaPlayerCtrl scrMedia;

    void FixedUpdate() {

        int layer_mask = LayerMask.GetMask("Video Player");
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1, layer_mask)) {
            print("There is something in front of the object!");
            scrMedia.Play();
        } else {
            scrMedia.Pause();
        }
        
    }
}
