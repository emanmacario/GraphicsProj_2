using UnityEngine;
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
    private bool isJumping;
    private Vector3 clamped;

    public void Start() {
        tf = this.transform;
        rb = this.gameObject.GetComponent<Rigidbody>();
        if (translateForce < 0) translateForce = DEFAULT_TRANSLATE_FORCE;
        if (jumpForce < 0) jumpForce = DEFAULT_JUMP_FORCE;
        if (maxTranslateSpeed < 0) maxTranslateSpeed = DEFAULT_MAX_TRANSLATE_SPEED;
    }

    // Restrict ONLY speed along the XZ plane
    // Leave gravity (along Y-axis) unchanged
    private void clampTranslationSpeed() {
        Vector3 rbVel = rb.velocity;
        clamped = Vector3.zero;
        clamped.x = rbVel.x; clamped.z = rbVel.z;
        clamped = Vector3.ClampMagnitude(clamped, maxTranslateSpeed);
        clamped.y = rbVel.y;
        rb.velocity = clamped;
    }

    public void Update() {

        float translateMag = translateForce * Time.deltaTime;

        if (Input.GetKey("w") || Input.GetKey(",")) rb.AddForce(translateMag * Vector3.forward);
        if (Input.GetKey("a") || Input.GetKey("a")) rb.AddForce(translateMag * Vector3.left);
        if (Input.GetKey("s") || Input.GetKey("o")) rb.AddForce(translateMag * Vector3.back);
        if (Input.GetKey("d") || Input.GetKey("e")) rb.AddForce(translateMag * Vector3.right);
        if (Input.GetKey("space") && !isJumping) rb.AddForce(jumpForce * Vector3.up);

        clampTranslationSpeed();

    }

    public void OnCollisionEnter(Collision c) {
        isJumping = false;
    }

    public void OnCollisionExit(Collision c) {
        isJumping = true;
    }

}
