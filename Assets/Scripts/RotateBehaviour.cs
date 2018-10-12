using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehaviour : MonoBehaviour {

    // Rotates an object about each of the three axis
    void Update() {
        transform.Rotate(new Vector3(15.0f, 30.0f, 45.0f) * Time.deltaTime);
    }

}
