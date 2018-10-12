using UnityEngine;
using System;
using System.Collections;

public class ShootAbility : MonoBehaviour {

    public float recoilForce;
    public float fireDelay;
    public GameObject typeA;
    public GameObject typeB;

    private Camera cam;
    private Transform tf;
    private Rigidbody rb;
    private float timeFiredAgo;

    private void fire(GameObject type, Vector3 target) {
        GameObject g = Instantiate(type, tf.position, Quaternion.identity);
        ProjectileBehaviour p = g.GetComponent<ProjectileBehaviour>();
        Vector3 dir = target - tf.position;
        p.setDir(dir);
        rb.AddForce(recoilForce * -dir);
    }

    public void Start() {
        cam = Camera.main;
        tf = this.gameObject.transform;
        rb = this.gameObject.GetComponent<Rigidbody>();
        timeFiredAgo = 0;
    }

    public void Update() {
        timeFiredAgo += Time.deltaTime;
        bool L = Input.GetMouseButton(0);
        bool R = Input.GetMouseButton(1);
        if ((L || R) && (timeFiredAgo > fireDelay)) {
            Vector2 mouse = Input.mousePosition;
            Vector3 target = cam.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, -cam.gameObject.transform.position.z));
            if (L) fire(typeA, target);
            if (R) fire(typeB, target);
            timeFiredAgo = 0;
        }
    }

}
