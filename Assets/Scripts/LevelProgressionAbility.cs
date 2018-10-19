using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgressionAbility : MonoBehaviour {

    public GameObject levelProgressionObject;

    public void OnTriggerEnter(Collider c) {
        String t = c.tag;
        if (t.Equals("NextLevel")) {
            Console.WriteLine("If player satisfies win condition, move to next level");
        }
    }

}
