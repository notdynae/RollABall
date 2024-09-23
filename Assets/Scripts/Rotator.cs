using UnityEngine;

public class Rotator : MonoBehaviour {

    public Vector3 rotate;
    // Update is called once per frame
    void Update() {
        // Rotate the object on X, Y, and Z axes by specified amounts, adjusted for frame rate.
        transform.Rotate(rotate * Time.deltaTime);
    }

}
