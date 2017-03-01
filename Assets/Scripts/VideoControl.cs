using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoControl : MonoBehaviour {

    int layer_mask1;
    bool rayHit = false;
    GameObject tempGameObject;

    private void Start() {
        layer_mask1 = LayerMask.GetMask("Player");
    }

    void FixedUpdate() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1, layer_mask1)) {
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

        //if (Physics.Raycast(ray, out hit, 1, layer_mask1)) {
        //    tempGameObject = hit.transform.gameObject;
        //    tempGameObject.SendMessage("HitByRay");
        //    rayHit = true;
        //} else {
        //    if (rayHit) {
        //        tempGameObject.SendMessage("Pause");
        //        rayHit = false;
        //    } else {
        //        return;
        //    }
        //}

    }
}
