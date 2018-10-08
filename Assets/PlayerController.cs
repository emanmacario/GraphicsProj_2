using UnityEngine;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float translateForce = -1;
    public float jumpForce = -1;
    public float maxTranslateSpeed = -1;

    private float DEFAULT_TRANSLATE_FORCE = 1000;
    private float DEFAULT_JUMP_FORCE = 50;
    private float DEFAULT_MAX_TRANSLATE_SPEED = 5;
    private Transform tf;
    private Rigidbody rb;
    private bool canJump;

    public void Start() {
        tf = this.transform;
        rb = this.gameObject.GetComponent<Rigidbody>();
        canJump = false;
        if (translateForce < 0) translateForce = DEFAULT_TRANSLATE_FORCE;
        if (jumpForce < 0) jumpForce = DEFAULT_JUMP_FORCE;
        if (maxTranslateSpeed < 0) maxTranslateSpeed = DEFAULT_MAX_TRANSLATE_SPEED;
    }

    public void Update() {

        float translateMag = translateForce * Time.deltaTime;

        if (Input.GetKey("w") || Input.GetKey(",")) rb.AddForce(translateMag * Vector3.forward);
        if (Input.GetKey("a") || Input.GetKey("a")) rb.AddForce(translateMag * Vector3.left);
        if (Input.GetKey("s") || Input.GetKey("o")) rb.AddForce(translateMag * Vector3.back);
        if (Input.GetKey("d") || Input.GetKey("e")) rb.AddForce(translateMag * Vector3.right);
        if (Input.GetKeyDown("space") && canJump) rb.AddForce(jumpForce * Vector3.up);

    }

    public void OnTriggerEnter(Collider c) {
        if (c.name == "JumpPlane") canJump = true;
    }

    public void OnTriggerExit(Collider c) {
        if (c.name == "JumpPlane") canJump = false;
    }

}
