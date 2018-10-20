using UnityEngine;
using System;
using System.Collections;

public class GravityGiver : MonoBehaviour {

    private bool given = false;

    public void OnTriggerEnter(Collider c) {
        Console.WriteLine("TriggerEnter ->");
        Console.WriteLine(c.name);
        Console.WriteLine(c.tag);
        if (!given) {
            c.gameObject.AddComponent<GravityAbility>();
            given = true;
        }
    }

}
