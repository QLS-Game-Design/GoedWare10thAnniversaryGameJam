using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public float JumpForce = 1f;
    public float dashSpeed = 15f;
    public float dashTime = 0.1f;

    private Rigidbody2D rigidbody;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private TrailRenderer trailRenderer;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.emitting = false;
    }

    private void Update()
    {
        // Left - Right Movement
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        // Crouching and dashing
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            trailRenderer.emitting = true;
            isDashing = true;
            MovementSpeed = dashSpeed;
            dashTimer = dashTime;
        }

        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
            {
                trailRenderer.emitting = false;
                isDashing = false;
                MovementSpeed = 5f;
            }
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody.velocity.y) < 0.001f)
        {
            rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

}