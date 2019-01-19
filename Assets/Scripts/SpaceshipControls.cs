using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipControls : MonoBehaviour {

    public Rigidbody2D rb;
    public float thrust;
    public float turnThrust;
    private float thrustInput;
    private float turnInput;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        //Check for input from the keyboard
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        //Screen Wraping
        Vector2 newPos = transform.position;
        if(transform.position.y > screenTop) {
            newPos.y = screenBottom;
        }
        if(transform.position.y < screenBottom) {
            newPos.y = screenTop;
        }
        if(transform.position.x > screenRight) {
            newPos.x = screenLeft;
        }
        if(transform.position.x < screenLeft) {
            newPos.x = screenRight;
        }
        transform.position = newPos;
    }

    void FixedUpdate() {
        rb.AddRelativeForce(Vector2.up * thrustInput);
        rb.AddTorque(-turnInput);
    }
}
