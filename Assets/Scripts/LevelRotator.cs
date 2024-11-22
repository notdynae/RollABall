using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRotator : MonoBehaviour
{
    public PlayerController player;
    public GameStateManager gameStateManager;
    public GameObject level;
    private float rotationX, rotationY, rotateSpeed;

    void Start() {
        rotateSpeed = 500f;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameStateManager.rotating) {
            rotationX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
            rotationY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
            transform.RotateAround(level.transform.position, Vector3.up, rotationX);
            transform.RotateAround(level.transform.position, Vector3.forward, rotationY);
        }

        if (gameStateManager.rotating && Input.GetKeyDown(KeyCode.Space)) {
            gameStateManager.GameplayState();
        }
    }
}
