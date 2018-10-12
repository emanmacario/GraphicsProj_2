using UnityEngine;
using System;
using System.Collections;

public class PlayerGravity : MonoBehaviour {

    public void Update() {
        if (Input.GetKeyDown("f")) {
            Physics.gravity *= -1;
        }
    }

}
