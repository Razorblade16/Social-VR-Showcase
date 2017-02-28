using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoControl : MonoBehaviour {

    bool rayHit = false;
    GameObject tempGameObject;

    void FixedUpdate() {

        int layer_mask = LayerMask.GetMask("Video Player");
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1, layer_mask)) {
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
