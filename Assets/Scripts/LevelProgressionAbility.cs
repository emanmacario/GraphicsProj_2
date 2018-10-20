using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgressionAbility : MonoBehaviour {

    public GameObject levelProgressionObject;

    private static const float PORTAL_SOUND_TIME = 1.0f;
    private static const float FREEZE_SCENE = 0.0f;

    private MeshRenderer mr;
    private AudioManager am;
    private PauseManager pm;

    public void nextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Start() {
        mr = this.gameObject.GetComponent<MeshRenderer>();
        am = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        pm = new PauseManager(this, PORTAL_SOUND_TIME, FREEZE_SCENE, nextScene);
    }

    public void OnTriggerEnter(Collider c) {
        String t = c.tag;
        if (t.Equals("NextLevel")) {
            am.Play("Portal");
            mr.enabled = false;
            pm.StartPause();
        }
    }

}
