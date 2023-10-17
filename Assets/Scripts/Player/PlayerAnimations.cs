using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    //Public Variables
    public Player_Movement playerMovement;
    public GroundDetector groundDetector;

    //Private Variables
    private float speed;
    private bool isGrounded;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        isGrounded = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGound();
        CheckkSpeed();
        SetParameters();
    }

    void SetParameters()
    {
        animator.SetFloat("Speed", speed);
        animator.SetBool("IsGrounded", isGrounded);
    }

    public void CheckkSpeed()
    {
        speed = playerMovement.GetCurrentSpeed();
    }

    public void CheckGound()
    {
        isGrounded = groundDetector.GetIsGrounded();
    }
}
