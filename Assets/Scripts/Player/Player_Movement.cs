using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //Public Variables
    public float walkSpeed, runSpeed;
    public bool canMove;

    //Private Variables
    private Vector3 vectorMovement;
    private float speed;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        //Initialization of variables
        characterController = GetComponent<CharacterController>();
        speed = walkSpeed;
        vectorMovement = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            Walk();
            Run();
        }
        Gravity();
    }

    //Walking Function
    void Walk()
    {
        //we get inputs
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");

        //Normalize vector movement
        vectorMovement = vectorMovement.normalized;

        //Move player
        characterController.Move(vectorMovement * speed * Time.deltaTime);
    }
    
    //Running function
    void Run()
    {
        //If Run button pressed, speed is modified
        if(Input.GetAxis("Run") >  0f)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }

    //Provisional gravity Function
    void Gravity()
    {
        characterController.Move(new Vector3(0f, -4f * Time.deltaTime, 0f));
    }
}
