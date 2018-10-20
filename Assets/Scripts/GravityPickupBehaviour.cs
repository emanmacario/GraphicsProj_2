using UnityEngine;
using System;
using System.Collections;

public class GravityPickupBehaviour : MonoBehaviour {

    public void OnTriggerEnter(Collider c) {
        String t = c.tag;
        if (t.Equals("Player")) {
            c.gameObject.AddComponent<GravityAbility>();
            Destroy(this.gameObject);
        }
    }

}
