using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealthBehaviour : MonoBehaviour {

    // Time in secs, player can contact enemy before dying
    public float health = 5;

    private float startHealth;
    private Rigidbody rb;
    private MeshRenderer mr;
    private ParticleSystem ps;
    private ParticleSystem.EmissionModule em;
    private PauseManager pm;

    private void playerDies() {
        rb.detectCollisions = false;
        ps.Play();
        pm.StartPause();
    }

    public void reflectHealth() {
        mr.material.SetColor("_Color", Color.Lerp(Color.red, Color.green, (startHealth-health)/startHealth));
    }

    public void Start() {
        startHealth = health;
        rb = this.gameObject.GetComponent<Rigidbody>();
        mr = this.gameObject.GetComponent<MeshRenderer>();
        ps = GetComponent<ParticleSystem>();
        em = ps.emission;
        pm = new PauseManager(this, 5.0f, 1.0f, () => SceneManager.LoadScene("MainMenu"));
        ps.Stop();
    }

    public void Update() {
        reflectHealth();
    }

    public void OnCollisionStay(Collision c) {
        String t = c.collider.tag;
        if (t.Equals("Enemy")) {
            health -= Time.deltaTime;
            if (health <= 0) playerDies();
        }
    }

}
