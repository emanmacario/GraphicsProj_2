using UnityEngine;
using System;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float translateForce = -1;
    public float jumpForce = -1;

    private Transform tf;
    private Rigidbody rb;
    private bool canJump;

    public void Start() {
        cam = Camera.main;
        tf = this.transform;
        rb = this.gameObject.GetComponent<Rigidbody>();
        canJump = false;
    }

    public void Update() {
        float translateMag = translateForce * Time.deltaTime;
        if (Input.GetKey("a") || Input.GetKey("a")) rb.AddForce(translateMag * Vector3.left);
        if (Input.GetKey("d") || Input.GetKey("e")) rb.AddForce(translateMag * Vector3.right);
        if (Input.GetKeyDown("space") && canJump) rb.AddForce(jumpForce * -Physics.gravity);
    }

    public void OnTriggerEnter(Collider c) {
        bool normalGravity = Physics.gravity.y < 0;
        canJump = (normalGravity && c.tag.Equals("JumpUp")) || (!normalGravity && c.tag.Equals("JumpDown"));
    }

    public void OnTriggerExit(Collider c) {
        String t = c.tag;
        if (t.Equals("JumpUp") || t.Equals("JumpDown")) {
            canJump = false;
        }
    }

}
