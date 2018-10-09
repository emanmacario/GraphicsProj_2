using UnityEngine;
using System;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float agility;
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
    }

    public void OnTriggerExit(Collider c) {
    }

}
