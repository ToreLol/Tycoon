using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //Public Variables
    public Transform cameraAim;
    public float walkSpeed, runSpeed, jumpForce, rotationSpeed;
    public bool canMove;
    public GroundDetector groundDetector;

    //Private Variables
    private Vector3 vectorMovement, verticalForce;
    private float speed;
    private bool isGrounded;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        //Initialization of variables
        characterController = GetComponent<CharacterController>();
        speed = walkSpeed;
        verticalForce = Vector3.zero;
        vectorMovement = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //If can move
        if(canMove)
        {
            Walk();
            Run();
            AlignPlayer();
            Jump();
        }
        Gravity();
        CheckGround();
    }

    //Walking Function
    void Walk()
    {
        //we get inputs
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");

        //Normalize vector movement
        vectorMovement = vectorMovement.normalized;

        //Move where camera faces
        vectorMovement = cameraAim.TransformDirection(vectorMovement);

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

    //Jump Function
    void Jump()
    {
        //If Player is touching ground and presses Spacebar
        if(isGrounded && Input.GetAxis("Jump") > 0f)
        {
            verticalForce = new Vector3(0f, jumpForce, 0f);
            isGrounded = false;
        }
    }

    //Provisional gravity Function
    void Gravity()
    {
        //characterController.Move(new Vector3(0f, -4f * Time.deltaTime, 0f));
        //If Player is not touching ground
        if(!isGrounded)
        {
            verticalForce += Physics.gravity * Time.deltaTime;
        }
        else
        {
            verticalForce = new Vector3 (0f, -2f, 0f);
        }

        //Applies vertical force
        characterController.Move(verticalForce * Time.deltaTime);
    }

    //Align player to where camera is facing Function
    void AlignPlayer()
    {
        //If moving, align rotation
        if (characterController.velocity.magnitude > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vectorMovement), rotationSpeed * Time.deltaTime);
        }
    }

    //Gets isGrounded value from detector Function
    void CheckGround()
    {
        isGrounded = groundDetector.GetIsGrounded();
    }
}
