using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ProjectileController : MonoBehaviour {

    public GameObject player;
    public GameObject typeA;
    public GameObject typeB;

    private Transform tf;
    private List<GameObject> projectiles;

    private void fire(GameObject type) {
        GameObject p = Instantiate(type, tf.position, Quaternion.identity);
        projectiles.Add(p);
    }

    public void Start() {
        tf = player.transform;
        projectiles = new List<GameObject>();
    }

    public void Update() {
        if (Input.GetMouseButtonDown(0)) fire(typeA);
        if (Input.GetMouseButtonDown(1)) fire(typeB);
    }

}
