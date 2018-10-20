using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void Start() {
		FindObjectOfType<AudioManager>().Play("MainMenuTheme");
	}

	public void PlayGame() {
		// Load the next scene according to the build settings scene indexes
		Invoke("LoadFirstScene", 1.5f);
	}

	public void QuitGame() {
		Debug.Log("Quit game successfully");
		Application.Quit();
	}

	public void LoadMainMenu() {
		SceneManager.LoadScene(0);
	}

	private void LoadFirstScene() {
		SceneManager.LoadScene(1);
	}
}