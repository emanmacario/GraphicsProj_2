using UnityEngine;
using System;
using System.Collections;

public class PlayerHealthBehaviour : MonoBehaviour {

    // Time in secs, player can contact enemy before dying
    public float health = 5;

    private float startHealth;
    private Rigidbody rb;
    private MeshRenderer mr;
    private ParticleSystem ps;
    private ParticleSystem.EmissionModule em;

    private void playerDies() {
        rb.detectCollisions = false;
        Console.WriteLine("Player died, go to finish screen");
    }

    public void Start() {
        startHealth = health;
        rb = this.gameObject.GetComponent<Rigidbody>();
        mr = this.gameObject.GetComponent<MeshRenderer>();
        ps = GetComponent<ParticleSystem>();
        em = ps.emission;
        ps.Play();
    }

    public void Update() {
        em = ps.emission;
        em.rateOverTime = health * 100;
    }

    public void OnCollisionStay(Collision c) {
        String t = c.collider.tag;
        if (t.Equals("Enemy")) {
            health -= Time.deltaTime;
            if (health <= 0) playerDies();
        }
    }

}
