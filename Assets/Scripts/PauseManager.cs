// Adapted from: https://forum.unity.com/threads/how-to-pause-a-game-x-seconds.433446/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    private MonoBehaviour mb;
    private float pauseTime;
    private float timeScale;
    private Action method;

    public PauseManager(MonoBehaviour mb, float pauseTime, float timeScale, Action method) {
        this.mb = mb;
        this.pauseTime = pauseTime;
        this.timeScale = timeScale;
        this.method = method;
    }

    public IEnumerator PauseGame() {
        Time.timeScale = timeScale;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime) yield return 0;
        Time.timeScale = 1;
        EndPause();
    }

    public void StartPause() { mb.StartCoroutine(PauseGame()); }

    public void EndPause() { method(); }

}
