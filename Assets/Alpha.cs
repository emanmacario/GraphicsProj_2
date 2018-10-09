using UnityEngine;
using System;
using System.Collections;

public class Alpha : MonoBehaviour {

    public float speed;

    private Transform tf;
    private Vector3 dir;

    public void Start() {
        tf = this.gameObject.transform;
        dir = Vector3.Normalize(Vector3.left);
    }

    public void Update() {
        tf.Translate(Time.deltaTime * speed * dir);
    }

    public void OnTriggerEnter(Collider c) {
        if (c.name.Contains("plat")) Destroy(this.gameObject);
    }


}
