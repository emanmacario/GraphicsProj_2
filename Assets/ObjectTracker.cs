using UnityEngine;
using System;
using System.Collections;

public class ObjectTracker : MonoBehaviour {

    public GameObject target;

    public void Start() {
    }

    public void Update() {
        Vector3 pos = target.transform.position;
        this.transform.position = new Vector3(pos.x, pos.y, this.transform.position.z);
    }

}
