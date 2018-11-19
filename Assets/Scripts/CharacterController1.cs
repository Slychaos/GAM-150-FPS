using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController1 : MonoBehaviour
{
    public Vector3 jumpVector;
    public float lookScale = 1;
    public float movementForce = 0.005f;
    private Rigidbody rigidBody;

    public bool trackMouse = true;

    
    

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        rigidBody.AddForce(transform.forward * movementForce * Input.GetAxis("Vertical"), ForceMode.Impulse);
        rigidBody.AddForce(transform.right * movementForce * Input.GetAxis("Horizontal"), ForceMode.Impulse);

        var playerRoatation = transform.localEulerAngles;

        if (trackMouse == true)
        {
            var camera = transform.Find("Main Camera");

            var cameraRotation = camera.transform.localEulerAngles;

            playerRoatation.y += Input.GetAxis("Mouse X") * lookScale;
            cameraRotation.x -= Input.GetAxis("Mouse Y") * lookScale;

            transform.localEulerAngles = playerRoatation;



            if ((cameraRotation.x > 30) && (cameraRotation.x < 180))
            {
                cameraRotation.x = 30;
            }

            if ((cameraRotation.x < 330) && (cameraRotation.x > 180))
            {
                cameraRotation.x = 330;
            }

            camera.transform.localEulerAngles = cameraRotation;

            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            trackMouse = !trackMouse;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(jumpVector, ForceMode.VelocityChange);
        }
    }
}