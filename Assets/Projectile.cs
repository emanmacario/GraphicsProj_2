using UnityEngine;
using System;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed;
    public Vector3 dir;

    public void setSpeed(float speed) { this.speed = speed; }
    public void setDir(Vector3 dir) { this.dir = Vector3.Normalize(dir); }

    private Transform tf;

    public virtual void Start() {
        tf = this.gameObject.transform;
    }

    public void Update() {
        tf.Translate(Time.deltaTime * speed * dir);
    }

    public void OnTriggerEnter(Collider c) {
        if (c.name.Contains("plat")) Destroy(this.gameObject);
    }

}
