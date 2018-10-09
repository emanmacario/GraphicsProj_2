using UnityEngine;
using System;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject player;

    public void Start() {
    }

    public void Update() {
    }

    public void OnTriggerEnter(Collider c) {
        /* if (c.name == "JumpPlane") canJump = true; */
    }

    public void OnTriggerExit(Collider c) {
        /* if (c.name == "JumpPlane") canJump = false; */
    }

}
