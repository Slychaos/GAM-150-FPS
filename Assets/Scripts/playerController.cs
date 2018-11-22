using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
   
    public float movementForce = 0.005f;
    public float lookScale = 1;

    bool trackMouse = true;

    public float hitImpulse;
   
	void Start ()
    {
	}
	
	void Update ()
    {
        var camera = transform.Find("camera");
        var rigidBody = GetComponent<Rigidbody>();

        string debugText = "";
        
        rigidBody.AddForce(camera.transform.transform.forward * movementForce * Input.GetAxis("Vertical"), ForceMode.Impulse);
        rigidBody.AddForce(camera.transform.transform.right * movementForce * Input.GetAxis("Horizontal"), ForceMode.Impulse);

        if (Input.GetButtonDown("Jump"))
        {
            rigidBody.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }

        var rotation = camera.localEulerAngles;

        rotation.y += Input.GetAxis("Mouse X") * lookScale;
        rotation.x -= Input.GetAxis("Mouse Y") * lookScale;

        if ((rotation.x > 30) && (rotation.x < 180))
        {
            rotation.x = 30;
        }

        if ((rotation.x < 330) && (rotation.x > 180))
        {
            rotation.x = 330;
        }

        debugText += rotation.x.ToString("0.0") + ":" + rotation.y.ToString("0.0");

        if (trackMouse == true)
        {           
            camera.localEulerAngles = rotation;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape) == true)
        {
            trackMouse = !trackMouse;
        }
        

        Ray ray = camera.GetComponent<Camera>().ScreenPointToRay(new Vector2(Screen.width/2.0f,Screen.height/2.0f));
        var hits = Physics.RaycastAll(ray, float.MaxValue);
      
        if (hits.Length > 0)
        {
            Array.Sort(hits, (x, y) => (int)(x.distance - y.distance));

            debugText += "\nScreen Hits:";
            foreach (var h in hits)
            {
                debugText += "\n" + h.distance.ToString("0.00") + ":" + h.transform.gameObject.name;
            }

            if (Input.GetButtonDown("Fire1") == true)
            {
                if (hits[0].transform.GetComponent<Rigidbody>() != null)
                {
                    var hitVector = camera.transform.transform.forward;                    

                    hits[0].transform.GetComponent<Rigidbody>().AddForce(hitVector * hitImpulse, ForceMode.Impulse);

                    var torque = new Vector3();

                    torque = UnityEngine.Random.onUnitSphere;
                    torque *= UnityEngine.Random.Range(1.0f, 10.0f);

                    hits[0].transform.GetComponent<Rigidbody>().AddTorque(torque, ForceMode.Impulse);
                }
            }
        }
        

        if (GameObject.Find("Canvas") != null)
        {
            GameObject.Find("Canvas").GetComponent<canvasController>().debugText = debugText;
        }
    }
}
