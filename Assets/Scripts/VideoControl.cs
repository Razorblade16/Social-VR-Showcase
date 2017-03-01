using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoControl : MonoBehaviour {

    bool rayHit = false;

    GameObject tempGameObject;

<<<<<<< HEAD

    private void Start() {
        layer_mask1 = LayerMask.GetMask("Player");
    }

=======
>>>>>>> parent of 1c53e67... Various VR optimizations
    void FixedUpdate() {
        int layer_mask1 = LayerMask.GetMask("Video Player");
        //int layer_mask2 = LayerMask.GetMask("Audio Player");

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

<<<<<<< HEAD
        if (Physics.Raycast(ray, out hit, 1, layer_mask1) && rayHit == false ) {
=======
        if (Physics.Raycast(ray, out hit, 1, layer_mask1) && rayHit == false) {
            tempGameObject = hit.transform.gameObject;
            tempGameObject.SendMessage("HitByRay");
            rayHit = true;
        } else {
            if (rayHit) {
                tempGameObject.SendMessage("Pause");
                rayHit = false;
            } else {
                return;
            }  
        }

        if (Physics.Raycast(ray, out hit, 1, layer_mask1)) {
>>>>>>> parent of 1c53e67... Various VR optimizations
            tempGameObject = hit.transform.gameObject;
            tempGameObject.SendMessage("HitByRay");
            rayHit = true;
        } else {
            if (rayHit) {
                tempGameObject.SendMessage("Pause");
                rayHit = false;
            } else {
                return;
            }
        }

    }
}
