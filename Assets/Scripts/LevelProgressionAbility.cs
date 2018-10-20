using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgressionAbility : MonoBehaviour {

    public GameObject levelProgressionObject;

    private AudioManager am;

    public void Start() {
        am = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public void OnTriggerEnter(Collider c) {
        String t = c.tag;
        if (t.Equals("NextLevel")) {
            am.Play("Portal");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
