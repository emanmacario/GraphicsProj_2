using UnityEngine;
using System;
using System.Collections;

public class RadABehaviour : ProjectileBehaviour {

    public void OnTriggerEnter(Collider c) {
        String t = c.tag;
        if (t.Equals("PlatV2") || t.Equals("Enemy")) Destroy(this.gameObject);
    }

}
