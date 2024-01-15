using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool isDestroyed = false;
    public int currHealth;
    public MadnessBar madnessBar;

    public int maxHealth;
    public float thrust;
    public float moveSpeed;
    Rigidbody2D rb2d;
    private GameObject player;

    void Start()
    {
        maxHealth = 100;
        currHealth = maxHealth;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 2.0f;

        // Dynamically find the player and madness bar at runtime
        FindPlayer();
        FindMadnessBar();
    }

    void Update()
    {
        
        // Check if the enemy is already destroyed
        if (!isDestroyed)
        {
            if (currHealth <= 0 && player != null)
            {
                PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    playerMovement.damageBuff++;
                    playerMovement.maxHealth += playerMovement.damageBuff * 3;
                    playerMovement.currHealth += playerMovement.damageBuff * 3;

                    if (madnessBar != null)
                    {
                        Debug.Log(madnessBar.getMadness());
                        madnessBar.SetMadness(madnessBar.getMadness() + 10);
                    }
                }

                // Set the flag to true to indicate that the enemy is destroyed
                isDestroyed = true;

                Destroy(gameObject);
            }
        }

        MoveTowardsPlayer();
    }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player GameObject not found!");
        }
    }

    void FindMadnessBar()
    {
        madnessBar = GameObject.FindObjectOfType<MadnessBar>();
        if (madnessBar == null)
        {
            Debug.LogError("MadnessBar not found!");
        }
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();

            rb2d.velocity = new Vector2(direction.x * moveSpeed, rb2d.velocity.y);
        }
    }

    public void Hit(int damage)
    {
        currHealth -= damage;
        Invoke("push", 0.3f);
    }

    private void push()
    {
        if (player != null && player.GetComponent<PlayerMovement>().spriteRenderer != null)
        {
            if (player.GetComponent<PlayerMovement>().spriteRenderer.flipX == true)
            {
                rb2d.AddForce(new Vector2(1, 0) * thrust, ForceMode2D.Impulse);
            }
            else
            {
                rb2d.AddForce(new Vector2(-1, 0) * thrust, ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().Hit(20);
            Debug.Log("Player hit by enemy");
        }
    }
}
