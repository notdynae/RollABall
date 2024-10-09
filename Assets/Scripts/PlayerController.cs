using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Cinemachine;

public class PlayerController : MonoBehaviour {

    // Rigidbody of the player.
    private Rigidbody rb;

    // Variable to keep track of collected "PickUp" objects.
    private int count;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;
    private Vector3 movement;

    // Speed at which the player moves.
    public float speed = 0;

    // UI text component to display count of "PickUp" objects collected.
    public TextMeshProUGUI countText;
    public GameObject countTextObject;

    public GameObject loseTextObject;

    // UI object to display winning text.
    public GameObject winTextObject;

    // Cinemachine camera refernces
	public Transform playerCam;

	// Start is called before the first frame update.
	void Start() {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();

        // Initialize count to zero.
        count = 0;

        // Update the count display.
        SetCountText();

        // Initially set the win text to be inactive.
        loseTextObject.SetActive(false);
        winTextObject.SetActive(false);

    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue) {

		// Convert the input value into a Vector2 for movement.
		Vector2 movementVector = movementValue.Get<Vector2>();

		// Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate() {

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }
	private void LateUpdate() {

		// Get the direction the camera is facing, constrained to the Y-axis only
		Vector3 cam = Camera.main.transform.forward;
		cam.y = 0;  // Ensure no vertical rotation is applied (Y-axis locked)

		// (cam.forward.x, 0, cam.forward.z).normalized

		// Calculate the new rotation that matches the camera's facing direction
		Quaternion targetRotation = Quaternion.LookRotation(cam.normalized);
		// Create a 3D movement vector using the X and Y inputs.
		movement = new Vector3(movementX, 0.0f, movementY);

		movement = targetRotation * movement;
	}

	void OnTriggerEnter(Collider other) {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            // Increment the count of "PickUp" objects collected.
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy")) {
            // Deactivate the collided object (making it disappear).
            rb.gameObject.SetActive(false);
            SetLoseScreen();
        }
		else if (other.gameObject.CompareTag("Goal")) {
			Debug.Log("Goal Reached");
			return;
		}
	}

    // Function to update the displayed count of "PickUp" objects collected.
    void SetCountText() {
        // Update the count text with the current count.
        countText.text = "Rings: " + count.ToString();

        // Check if the count has reached or exceeded the win condition.
        if (count >= 8) {
            // Display the win text.
            winTextObject.SetActive(true);
            rb.gameObject.SetActive(false);
        }
    }
    // Correctly enables and disables ui elements when enemy is hit
    void SetLoseScreen() {
        countTextObject.SetActive(false);
        winTextObject.SetActive(false);
        loseTextObject.SetActive(true);
    }
}
