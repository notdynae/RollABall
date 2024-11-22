using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject rotateCam;
    public bool rotating = false;

    public void GameplayState() {
	    rotating = false;
        playerController.rb.isKinematic = false;
        playerController.rb.gameObject.SetActive(true);
        rotateCam.gameObject.SetActive(false);
	}   
    public void RotateState() {
	    rotating = true;
        playerController.rb.isKinematic = true;
        playerController.rb.gameObject.SetActive(false);
		rotateCam.gameObject.SetActive(true);
    }

}
