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
		Invoke("LoadNextScene", 2.0f);
	}

	public void QuitGame() {
		Debug.Log("Quit game successfully");
		Application.Quit();
	}

	private void LoadNextScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}