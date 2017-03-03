using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoControl : MonoBehaviour {

    bool rayHit = false;

    GameObject tempGameObject;
    int layer_mask1;
    int layer_mask2;

    private void Start() {
        layer_mask1 = LayerMask.GetMask("AudioPlayer");
        layer_mask2 = LayerMask.GetMask("VideoPlayer");
    }


    void FixedUpdate() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1, layer_mask1)) {
            tempGameObject = hit.transform.gameObject;
            tempGameObject.GetComponent<AudioPlayer>().HitByRay();
        } else if (Physics.Raycast(ray, out hit, 1, layer_mask2)) {
            tempGameObject = hit.transform.gameObject;
            tempGameObject.GetComponent<VideoPlayer>().HitByRay();

        } else if (tempGameObject != null) {
                tempGameObject.SendMessage("Pause");
            
        }  
    }
}
