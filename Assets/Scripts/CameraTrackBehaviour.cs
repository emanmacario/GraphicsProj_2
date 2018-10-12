using UnityEngine;
using System;
using System.Collections;

public class CameraTrackBehaviour : MonoBehaviour {

    public GameObject target;

    public void Update() {
        Vector3 pos = target.transform.position;
        this.transform.position = new Vector3(pos.x, pos.y, this.transform.position.z);
    }

}
