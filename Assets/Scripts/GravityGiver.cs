using UnityEngine;
using System;
using System.Collections;

public class GravityGiver : MonoBehaviour {

    private bool given = false;

    public void OnTriggerEnter(Collider c) {
        String t = c.tag;
        if (t.Equals("Player") && !given) {
            c.gameObject.AddComponent<GravityAbility>();
            given = true;
        }
    }

}
