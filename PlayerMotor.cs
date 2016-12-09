using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    private float speed1 = 5.0f;
    private float speed2 = 50.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 10.0f;
    private float animationDuration = 3.0f;


    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed1 * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed2;

        moveVector.y = verticalVelocity;

        moveVector.z = speed2;

        controller.Move(moveVector * Time.deltaTime);
	}
}
