using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public enum MovementType
    {
        keyboard,
        controller
    };
    public MovementType movementType;
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    float x;
    float z;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isOnGround;

    private void Update()
    {
        if (movementType == MovementType.keyboard)
        {
            isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isOnGround && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            //keyboardmovement
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isOnGround)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            if(movementType == MovementType.controller)
            {
                isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

                if (isOnGround && velocity.y < 0)
                {
                    velocity.y = -2f;
                }

                //keyboardmovement
                x = Input.GetAxis("HorizontalGamepad");
                z = Input.GetAxis("VerticalGamepad");

                Vector3 move = transform.right * x + transform.forward * z;

                controller.Move(move * speed * Time.deltaTime);

                if (Input.GetButtonDown("JumpGamepad") && isOnGround)
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }

                velocity.y += gravity * Time.deltaTime;

                controller.Move(velocity * Time.deltaTime);
            }
        }
    }
}
