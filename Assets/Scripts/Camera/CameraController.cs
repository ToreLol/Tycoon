using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Public Variables
    public float sensibility;
    public Transform cameraJointY, targetObject;
    public bool canRotate;

    //Private Variables
    private float xRotation, yRotation;

    // Start is called before the first frame update
    void Start()
    {
        //Initiallitation of Variables
        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        //If can rotate
        if (canRotate) Rotate();

        //Follow target
        FollowTarget();
    }

    //Camera Rotation Function
    void Rotate()
    {
        //Obtain mouse inputs
        xRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensibility;
        yRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * sensibility;

        //Adding limitation to y-rotation
        yRotation = Mathf.Clamp(yRotation, -65, 65);

        //Rotate X Y components
        transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
        cameraJointY.transform.localRotation = Quaternion.Euler(-yRotation, 0f, 0f);
    }

    //Function to follow target
    void FollowTarget()
    {
        transform.position = targetObject.position;
    }
}
