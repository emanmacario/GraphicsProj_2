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
		LightController lc = player.GetComponent<LightController>();
		if (lc != null) {
			if (lc.isInvisible) return;
		}
        Vector3 self = this.transform.position;
        Vector3 targ = player.transform.position;
        Vector3 dir = (targ - self).normalized;
        rb.AddForce(Time.deltaTime * agility * dir);
    }

    public void OnCollisionEnter(Collision c) {
        if (c.gameObject.name.Contains("RadA")) {
            rb.AddForce(100 * Vector3.up);
        }
        if (c.gameObject.name.Contains("RadB")) {
            rb.AddForce(100 * Vector3.down);
        }
    }

    public void OnTriggerExit(Collider c) {
    }

}
