using UnityEngine;
using System;
using System.Collections;

public class BasicAbility : MonoBehaviour {

    public float translateForce = 1200;
    public float jumpForce = 60;

    private Rigidbody rb;
    private AudioManager am;
    private bool canJump;

    public void Start() {
        rb = this.gameObject.GetComponent<Rigidbody>();
        am = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        canJump = false;
    }

    public void Update() {
        float translateMag = translateForce * Time.deltaTime;
        if (Input.GetKey("a") || Input.GetKey("a")) rb.AddForce(translateMag * Vector3.left);
        if (Input.GetKey("d") || Input.GetKey("e")) rb.AddForce(translateMag * Vector3.right);
        if (Input.GetKeyDown("space") && canJump) {
            rb.AddForce(jumpForce * -Physics.gravity);
            am.Play("Jump");
        }
    }

    public void OnCollisionEnter(Collision c) {
        String t = c.gameObject.tag;
        if (t.Equals("PlatV2")) am.Play("LandAfterJump");
    }

    public void OnTriggerEnter(Collider c) {
        String t = c.tag;
        bool normalGravity = Physics.gravity.y < 0;
        if (normalGravity && t.Equals("JumpUp") || !normalGravity && t.Equals("JumpDown")) canJump = true;
    }

    public void OnTriggerExit(Collider c) {
        String t = c.tag;
        if (t.Equals("JumpUp") || t.Equals("JumpDown")) canJump = false;
    }

}
