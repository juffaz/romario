using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 40;
    private Animator animator;
    private CharacterController2D controller;
    
    private float horizontalMove = 0;
    bool jump = false;
    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;           
        }

        if(controller.WasGrounded == true)
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }
        
    }

    

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
