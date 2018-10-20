using UnityEngine;
using System;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public float agility = 100;
    public GameObject player;

    private Vector3 lastPos;
    private Rigidbody rb;
    private LightAbility la;

    private void UpdateTrackingMode() {
        Vector3 self = this.transform.position;
        Vector3 targ = player.transform.position;
        Vector3 dir = (targ - self).normalized;
        rb.AddForce(Time.deltaTime * agility * dir);
    }

    private void UpdateWanderMode() {
    }

    public void Start() {
        lastPos = Vector3.zero;
        rb = this.GetComponent<Rigidbody>();
        la = player.GetComponent<LightAbility>();
    }

    public void Update() {
        if (la != null && la.isActivated()) UpdateWanderMode();
        else UpdateTrackingMode();
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
