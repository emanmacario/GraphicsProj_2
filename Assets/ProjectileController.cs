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

    private void fire() {
        GameObject p;
        p = Instantiate(typeA, tf.position, Quaternion.identity);
        projectiles.Add(p);
        p = Instantiate(typeB, tf.position, Quaternion.identity);
        projectiles.Add(p);
    }

    public void Start() {
        tf = player.transform;
        projectiles = new List<GameObject>();
    }

    public void Update() {
    }

}
