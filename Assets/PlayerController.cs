using UnityEngine;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float translateForce = -1;
    public float jumpForce = -1;
    public float fireDelay;
    public GameObject typeA;
    public GameObject typeB;

    private float DEFAULT_TRANSLATE_FORCE = 1000;
    private float DEFAULT_JUMP_FORCE = 50;
    private Camera cam;
    private Transform tf;
    private Rigidbody rb;
    private bool canJump;
    private float timeFiredAgo;

    private void fire(GameObject type, Vector3 target) {
        GameObject g = Instantiate(type, tf.position, Quaternion.identity);
        Projectile p = g.GetComponent<Projectile>();
        p.setDir(target - tf.position);
    }

    public void Start() {
        cam = Camera.main;
        tf = this.transform;
        rb = this.gameObject.GetComponent<Rigidbody>();
        canJump = false;
        timeFiredAgo = 0;
        if (translateForce < 0) translateForce = DEFAULT_TRANSLATE_FORCE;
        if (jumpForce < 0) jumpForce = DEFAULT_JUMP_FORCE;
    }

    public void Update() {
        float translateMag = translateForce * Time.deltaTime;
        if (Input.GetKey("a") || Input.GetKey("a")) rb.AddForce(translateMag * Vector3.left);
        if (Input.GetKey("d") || Input.GetKey("e")) rb.AddForce(translateMag * Vector3.right);
        if (Input.GetKeyDown("space") && canJump) rb.AddForce(jumpForce * Vector3.up);

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

    public void OnTriggerEnter(Collider c) {
        if (c.name == "JumpPlane") canJump = true;
    }

    public void OnTriggerExit(Collider c) {
        if (c.name == "JumpPlane") canJump = false;
    }

}
