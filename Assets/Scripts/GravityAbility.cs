using UnityEngine;
using System;
using System.Collections;

public class GravityAbility : MonoBehaviour {

    public void Update() {
        if (Input.GetKeyDown("f")) {
            Physics.gravity *= -1;
        }
    }

}
