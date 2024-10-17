using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[Header("Script References")]
	public UIManager uiManager;
	public PlayerController playerController;


	public int nextScene;
	//private int currentScene;

	public void LoadNextlevel() {
		nextScene = SceneManager.GetActiveScene().buildIndex + 1;

		if (nextScene <= SceneManager.sceneCountInBuildSettings) {
			LoadScene(nextScene);
		}

		else if (nextScene > SceneManager.sceneCountInBuildSettings) {
			Debug.Log("All levels complete!");
		}
	}

	void LoadScene(int sceneId) {
		SceneManager.sceneLoaded += OnSceneLoaded;
		SceneManager.LoadScene(sceneId);
	}

	public void LoadSelectLevel(int level) {
		nextScene = SceneManager.GetActiveScene().buildIndex + level;
		{
			LoadScene(nextScene);
		}
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		int LevelCount = SceneManager.GetActiveScene().buildIndex;

		Debug.Log("Scene Loaded: " + scene.name + " Build Index: " + scene.buildIndex);
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	public void QuitGame() {
		Application.Quit();
	}
}
