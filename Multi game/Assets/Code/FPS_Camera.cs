using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Go through each line of this script and explain what it does as we go through it
* Edit some of the variables and see what happens
*/

//What's this class for?
public class FPS_Camera : MonoBehaviour
{
    public float maximumX = 60f; //What is this?
    public float minimumX = -60f; //What is this?
    public float turnSpeed = 5f; //What is this?
    public Camera cam; //What is this for?
    float rotX = 0f;
    float rotY = 0f; 

    void Update()
    {
        PlayerLook();
        Cursor.lockState = CursorLockMode.Locked; //What does this do?
    }

    void PlayerLook()
    {
        rotX += Input.GetAxis("Mouse Y") * turnSpeed; //Why is rotX on mouse Y?
        rotY += Input.GetAxis("Mouse X") * turnSpeed; //Why is rotY on mouse X?

        rotX = Mathf.Clamp(rotX, minimumX, maximumX); //What does Clamp do?

        transform.localEulerAngles = new Vector3(0, rotY, 0); //What does a Euler Angle do?
        cam.transform.localEulerAngles = new Vector3(-rotX, 0, 0); //Why do we need 3 things after a vector3?
    }
}
