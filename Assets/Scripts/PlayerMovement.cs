using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public float JumpForce = 1f;
    public float dashSpeed = 15f;
    public float dashTime = 0.1f;

    private Rigidbody2D rigidbody;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private Animator animator;
    private float moveInput;
        private SpriteRenderer spriteRenderer;
    // private TrailRenderer trailRenderer;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // trailRenderer = GetComponent<TrailRenderer>();
        // trailRenderer.emitting = false;
    }

    private void Update()
    {
        // Left - Right Movement
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        // Crouching and dashing
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            // trailRenderer.emitting = true;
            isDashing = true;
            MovementSpeed = dashSpeed;
            dashTimer = dashTime;
        }

        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
            {
                // trailRenderer.emitting = false;
                isDashing = false;
                MovementSpeed = 5f;
            }
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody.velocity.y) < 0.001f)
        {
            rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
                // Check for left mouse button click
        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouse button
        {
            // Trigger the attack animation
            animator.SetTrigger("Attacks");
        }
                // Get horizontal movement input
        moveInput = Input.GetAxisRaw("Horizontal");

        // Trigger the movement animation
        animator.SetFloat("Speed", Math.Abs(moveInput) > 0 ? 1f : 0f);


        // Flip the player based on the direction
        FlipPlayer();
    }
    void FlipPlayer()
    {
        // If moving to the right, keep the sprite as it is
        if (moveInput > 0)
        {
            spriteRenderer.flipX = true;
        }
        // If moving to the left, flip the sprite horizontally
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = false;
        }
        // If not moving, maintain the current sprite orientation
        else
        {
            // You may want to add additional logic or animation handling here
        }
    }

}