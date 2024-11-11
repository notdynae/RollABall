using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Cinemachine;

public class UIManager : MonoBehaviour {

	// ---------------------------- script references

	public PlayerController playerController;

	// ---------------------------- gameObject references

	public GameObject mainMenuUI;
	public GameObject levelSelectUI;
	public GameObject gamePlayUI;

	// UI text component to display count of "PickUp" objects collected.
	public TextMeshProUGUI countText;
	public GameObject countTextObject;

	public GameObject loseTextObject;
	public GameObject winTextObject;
	
	public GameObject nextLevelObject;
	public GameObject restartLevelObject;

	// ---------------------------- ui switching methods

	public void UIMainMenu() {
		DisableAllUIPanels();
		mainMenuUI.SetActive(true);
	}
	public void UILevelSelect() {
		DisableAllUIPanels();
		levelSelectUI.SetActive(true);
	}
	public void UIGamePlay() {
		DisableAllUIPanels();
		gamePlayUI.SetActive(true);
		loseTextObject.SetActive(false);
		winTextObject.SetActive(false);
	}
	private void DisableAllUIPanels() {
		gamePlayUI.SetActive(false);
		mainMenuUI.SetActive(false);
		levelSelectUI.SetActive(false);
		loseTextObject.SetActive(false);
		winTextObject.SetActive(false);
		restartLevelObject.SetActive(false);
		nextLevelObject.SetActive(false);
	}


	// Function to update the displayed count of "PickUp" objects collected.
	public void SetCountText() {
		// Update the count text with the current count.
		countText.text = "Rings: " + playerController.count.ToString();
	}
	// Correctly enables and disables ui elements when enemy is hit
	public void SetLoseScreen() {
		countTextObject.SetActive(false);
		winTextObject.SetActive(false);
		loseTextObject.SetActive(true);
		restartLevelObject.SetActive(true);
	}

	public void SetWinScreen() {
		countTextObject.SetActive(false);
		winTextObject.SetActive(true);
		loseTextObject.SetActive(false);
		nextLevelObject.SetActive(true);
	}
}
