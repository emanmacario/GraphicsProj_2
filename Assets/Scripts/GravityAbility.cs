using UnityEngine;
using System;
using System.Collections;

public class GravityAbility : MonoBehaviour {

    private bool canFlipGravity;

    public void Start() {
        canFlipGravity = false;
    }

    public void Update() {
        if (Input.GetKeyDown("f") && canFlipGravity) {
            Physics.gravity *= -1;
        }
    }

    public void OnTriggerEnter(Collider c) {
        String t = c.tag;
        bool normalGravity = Physics.gravity.y < 0;
        canFlipGravity = (normalGravity && t.Equals("JumpUp")) || (!normalGravity && t.Equals("JumpDown"));
    }

    public void OnTriggerExit(Collider c) {
        String t = c.tag;
        if (t.Equals("JumpUp") || t.Equals("JumpDown")) {
            canFlipGravity = false;
        }
    }

}
