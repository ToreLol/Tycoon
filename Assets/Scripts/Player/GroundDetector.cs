using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    //Public Variables
    public float radius;
    public LayerMask detectedLayers;

    //Private Variables
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        CheckGround();
    }

    //Check if player is touching ground
    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(transform.position, radius, detectedLayers);
    }

    //Return isGrounded Value Function
    public bool GetIsGrounded()
    {
        return isGrounded;
    }
}
