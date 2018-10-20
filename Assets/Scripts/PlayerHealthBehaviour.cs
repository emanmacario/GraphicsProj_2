using UnityEngine;
using System;
using System.Collections;

public class PlayerHealthBehaviour : MonoBehaviour {

    // Time in secs, player can contact enemy before dying
    public float health = 8;

    private Rigidbody rb;
    private MeshRenderer mr;

    private void playerDies() {
        rb.detectCollisions = false;
        Console.WriteLine("Player died, go to finish screen");
    }

    public void Start() {
        rb = this.gameObject.GetComponent<Rigidbody>();
        mr = this.gameObject.GetComponent<MeshRenderer>();
    }

    public void Update() {
        if (health <= 0) playerDies();
    }

    public void OnCollisionStay(Collision c) {
        String t = c.collider.tag;
        if (t.Equals("Enemy")) health -= Time.deltaTime;
    }

}
