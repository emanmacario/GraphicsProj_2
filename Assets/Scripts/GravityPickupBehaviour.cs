using UnityEngine;
using System;
using System.Collections;
using TMPro;

public class GravityPickupBehaviour : MonoBehaviour {

    public GameObject notification;

    private AudioManager am;

    public void Start() {
        am = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public void OnTriggerEnter(Collider c) {
        String t = c.tag;
        if (t.Equals("Player")) {
            c.gameObject.AddComponent<GravityAbility>();
            notification.GetComponent<MeshRenderer>().enabled = true;
            am.Play("Pickup");
            Destroy(this.gameObject);
        }
    }

}
