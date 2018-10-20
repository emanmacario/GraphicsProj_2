using UnityEngine;
using System;
using System.Collections;

public class RadABehaviour : ProjectileBehaviour {

    private Rigidbody rb;
    private MeshRenderer mr;

    public override void Start() {
        base.Start();
        rb = this.gameObject.GetComponent<Rigidbody>();
        mr = this.gameObject.GetComponent<MeshRenderer>();
    }

    public void OnTriggerEnter(Collider c) {
        String t = c.tag;
        if (t.Equals("PlatV2")) Destroy(this.gameObject);
    }

}
