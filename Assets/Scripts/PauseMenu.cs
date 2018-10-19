using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool isPaused = false;
	public GameObject pauseMenuPanel;

	public void Start() {
		pauseMenuPanel.SetActive(false);
	}

	public void Update() {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
			{
				Resume();
			} else
			{
				Pause();
			}
		}
	}

	private void Pause() {
		isPaused = true;
		pauseMenuPanel.SetActive(true);
		Time.timeScale = 0.0f;
	}

	public void Resume() {
		isPaused = false;
		pauseMenuPanel.SetActive(false);
		Time.timeScale = 1.0f;
	}

	public void MainMenu() {
		SceneManager.LoadScene(0);
	}

	public void Quit() {
		Debug.Log("Quit game successfully");
		Application.Quit();
	}
}
