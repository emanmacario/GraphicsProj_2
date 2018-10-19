using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBehaviour : MonoBehaviour {

    public GameObject player;
    public float speed = 5;
    public float growFactor = 4;

    private LightAbility lightAbility;
    private MeshRenderer rend;
    private float startRad = 0;
    private float shrinkTime, growTime;

    void Start() {
        rend = this.gameObject.GetComponent<MeshRenderer>();
        lightAbility = player.GetComponent<LightAbility>();
    }

    // Update is called once per frame
    void Update () {
        if (lightAbility.isActivated()) {
            rend.material.SetVector("_invPla", lightAbility.transform.position);
            if (growTime < Mathf.PI/2) {
                shrinkTime = 0;
                growTime += Time.deltaTime*speed*growFactor;
                startRad = lightAbility.getRadius() * Mathf.Sin(growTime);
                rend.material.SetFloat("_invRad", startRad);
            }
        } else if (shrinkTime < Mathf.PI/2) {
            growTime = 0;
            rend.material.SetVector("_invPla", lightAbility.transform.position);
            shrinkTime += Time.deltaTime*speed;
            rend.material.SetFloat("_invRad", startRad * Mathf.Cos(shrinkTime));
        }

    }
}
