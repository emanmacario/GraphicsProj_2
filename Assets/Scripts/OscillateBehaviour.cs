using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillateBehaviour : MonoBehaviour {

    public float magnitude;
    public float period;
    public float phaseDeg;

    private float currTime;
    private float toAngle;
    private float phaseRad;

    void Start() {
        currTime = 0;
        toAngle = 2 * Mathf.PI / period;
        phaseRad = phaseDeg * Mathf.PI / 180;
    }

    void Update() {
        currTime += Time.deltaTime;
        if (currTime > period) currTime -= period;
        float newX = magnitude * Mathf.Cos(currTime*toAngle + phaseRad);
        Vector3 old = transform.position;
        transform.position = new Vector3(newX, old.y, old.z);
    }

}
