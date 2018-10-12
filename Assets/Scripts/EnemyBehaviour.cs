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

}