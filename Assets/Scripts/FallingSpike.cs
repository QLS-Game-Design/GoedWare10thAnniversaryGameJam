using System.Collections;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    public float minY = -5f;  // The minimum y position for the spike to drop down
    public float maxY = 5f;   // The maximum y position for the spike to drop down
    public float moveSpeed = 0.6f; 
    public PlayerMovement playerMovement;

    private void Start()
    {
        // Find the player GameObject by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Assign the PlayerMovement component from the player GameObject
            playerMovement = player.GetComponent<PlayerMovement>();

            if (playerMovement == null)
            {
                Debug.LogError("PlayerMovement component not found on the player!");
                return;
            }
        }
        else
        {
            Debug.LogError("Player GameObject not found!");
            return;
        }

        MoveToRandomX();
    }

    private void Update()
    {
        // Moves down
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        // Check if the spike is at the target x position
        if (Mathf.Approximately(transform.position.x, targetX))
        {
            // Drop the spike down
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
    }

    float targetX;

    void MoveToRandomX()
    {   
        // Set a random target x position near player
        targetX = Random.Range(playerMovement.getXPos() - 2f, playerMovement.getXPos() + 2f);
        Debug.Log(targetX);
        transform.position = new Vector2(targetX, maxY);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            other.gameObject.GetComponent<PlayerMovement>().Hit(20);
            Debug.Log("Hit Player");
        }
        else if (other.gameObject.CompareTag("Enemy")) 
        {
            other.gameObject.GetComponent<EnemyController>().Hit(15);
            Debug.Log("Hit Enemy");
        }

        Destroy(gameObject);
    }
}
