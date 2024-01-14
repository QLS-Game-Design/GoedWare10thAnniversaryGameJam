using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public int currentMadness;
    public MadnessBar madnessBar;
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

    public int damage;

    public int currHealth;
    public int maxHealth;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // trailRenderer = GetComponent<TrailRenderer>();
        // trailRenderer.emitting = false;

        damage = 30;

        maxHealth = 100;
        currHealth = maxHealth;

        currentMadness = 0;
        madnessBar.set
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
            animator.SetFloat("Jumping", 1);
        }
        else if(Mathf.Abs(rigidbody.velocity.y) < 0.015) {
            animator.SetFloat("Jumping",0);
        }
                // Check for left mouse button click
        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouse button
        {
            if (transform.GetComponentInChildren<Weapon>().canHit) {
                animator.SetTrigger("Attacks");
                transform.GetComponentInChildren<Weapon>().attack(damage);
                transform.GetComponentInChildren<Weapon>().canHit = false;
            }
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
            foreach(Transform child in this.transform) {
                Vector3 newPos = new Vector3(this.transform.position.x+1.5f, this.transform.position.y, this.transform.position.z);
                child.position = newPos;
            }
        }
        // If moving to the left, flip the sprite horizontally
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = false;
            foreach(Transform child in this.transform) {
                Vector3 newPos = new Vector3(this.transform.position.x-1.5f, this.transform.position.y, this.transform.position.z);
                child.position = newPos;
            }
        }
        // If not moving, maintain the current sprite orientation
        else
        {
            // You may want to add additional logic or animation handling here
        }
   
    }

}