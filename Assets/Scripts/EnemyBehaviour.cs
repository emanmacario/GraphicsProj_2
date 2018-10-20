using UnityEngine;
using System;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public float agility = 100;
    public GameObject player;

    private Rigidbody rb;

    public void Start() {
        rb = this.GetComponent<Rigidbody>();
    }

    public void Update() {
        Vector3 self = this.transform.position;
        Vector3 targ = player.transform.position;
        Vector3 dir = (targ - self).normalized;
        rb.AddForce(Time.deltaTime * agility * dir);
    }

    public void OnTriggerEnter(Collider c) {
        String t = c.tag;
        Vector3 dir = (this.transform.position - player.transform.position).normalized;
        if (t.Equals("RadA")) {
            rb.AddForce(100 * dir);
        } else if (t.Equals("RadB")) {
            rb.AddForce(1000 * dir);
        }
    }

}
