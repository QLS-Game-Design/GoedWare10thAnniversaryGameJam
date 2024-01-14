using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpikeMovement : MonoBehaviour
{
    public float minY = -5f;  // The minimum y position for the spike to drop down
    public float maxY = 5f;   // The maximum y position for the spike to drop down
    public float moveSpeed = 1f; 
    public PlayerMovement playerMovement;
    private void Start()
    {
        MoveToRandomX();
    }

    private void Update()
    {
        // Move the spike horizontally
        // transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        // // Check if the spike is at the target x position
        // if (Mathf.Approximately(transform.position.x, transform.GetComponent<RandomSpikeMovement>().targetX))
        // {
        //     // Drop the spike down
        //     transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        // }
    }

    float targetX;

    void MoveToRandomX()
    {   
        
        // Set a random target x position
        targetX = Random.Range(playerMovement.getXPos() - 1f, playerMovement.getXPos() + 1f);
        // Move the spike to the target x position
        transform.position = new Vector2(targetX, maxY);
    }
}