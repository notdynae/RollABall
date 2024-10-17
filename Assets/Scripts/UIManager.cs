using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Cinemachine;

public class UIManager : MonoBehaviour
{
	// ---------------------------- gameObject references

	public GameObject mainMenuUI;
	public GameObject levelSelectUI;
	public GameObject gamePlayUI;

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
	}
	public void DisableAllUIPanels() {
		gamePlayUI.SetActive(false);
		mainMenuUI.SetActive(false);
		levelSelectUI.SetActive(false);
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
