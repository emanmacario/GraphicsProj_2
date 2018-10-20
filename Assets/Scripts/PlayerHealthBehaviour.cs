using UnityEngine;
using System;
using System.Collections;

public class PlayerHealthBehaviour : MonoBehaviour {

    public int health = 8;

    private Rigidbody rb;
    private MeshRenderer mr;

    private void playerDies() {
        rb.isKinematic = true;
        rb.detectCollisions = false;
        mr.enabled = false;
    }

    public void Start() {
        rb = this.gameObject.GetComponent<Rigidbody>();
        mr = this.gameObject.GetComponent<MeshRenderer>();
    }

    public void Update() {
        if (health <= 0) {
            playerDies();
        }
    }

    public void OnCollisionEnter(Collision c) {
        String t = c.collider.tag;
        if (t.Equals("Enemy")) {
            health--;
        }
    }

}
