using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpikeMovement : MonoBehaviour
{
    public float minY = -5f;  // The minimum y position for the spike to drop down
    public float maxY = 5f;   // The maximum y position for the spike to drop down
    public float moveSpeed = 0.6f; 
    public PlayerMovement playerMovement;
    private void Start()
    {
        MoveToRandomX();
        Destroy(game);
    }

    private void Update()
    {
        //moves down
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        //Check if the spike is at the target x position
        if (Mathf.Approximately(transform.position.x, transform.GetComponent<RandomSpikeMovement>().targetX))
        {
            //Drop the spike down
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
        //destroy after min y reached
    }

    float targetX;

    void MoveToRandomX()
    {   
        //Set a random target x position near player
        targetX = Random.Range(playerMovement.getXPos() - 2f, playerMovement.getXPos() + 2f);
        Debug.Log(targetX);
        transform.position = new Vector2(targetX, maxY);
    }
}