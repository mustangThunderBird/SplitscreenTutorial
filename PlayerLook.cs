using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public enum LookType
    {
        keyboard,
        controller
    };
    public LookType lookType;
    public float mouseSensitivity = 245f;

    public Transform playerBody;

    float xRotation = 0f;

    public Camera cam;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(lookType == LookType.keyboard)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f).normalized;
            playerBody.Rotate(Vector3.up * mouseX);
        }
        else
        {
            if(lookType == LookType.controller)
            {
                float mouseX = Input.GetAxis("Gamepad X") * mouseSensitivity * Time.deltaTime;
                float mouseY = Input.GetAxis("Gamepad Y") * mouseSensitivity * Time.deltaTime;

                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f).normalized;
                playerBody.Rotate(Vector3.up * mouseX);
            }
        }
    }
}
