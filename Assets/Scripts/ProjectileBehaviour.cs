using UnityEngine;
using System;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour {

    public float lifetime;
    public float speed;
    public Vector3 dir;

    public void setLifetime(float lifetime) { this.lifetime = lifetime; }
    public void setSpeed(float speed) { this.speed = speed; }
    public void setDir(Vector3 dir) { this.dir = Vector3.Normalize(dir); }

    private float lived;
    private Transform tf;

    public virtual void Start() {
        tf = this.gameObject.transform;
    }

    public void Update() {
        lived += Time.deltaTime;
        if (lived > lifetime) Destroy(this.gameObject);
        tf.Translate(Time.deltaTime * speed * dir);
    }

}
