using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject rotateCam;

    public void GameplayState() {
        playerController.rb.isKinematic = false;
        rotateCam.gameObject.SetActive(false);
	}   
    public void RotateState() {
        playerController.rb.isKinematic = true;
		rotateCam.gameObject.SetActive(true);
	}

}
