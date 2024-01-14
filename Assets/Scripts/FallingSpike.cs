using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    public float minY = -5f;  // The minimum y position for the spike to drop down
    public float maxY = 5f;   // The maximum y position for the spike to drop down
    public float moveSpeed = 0.6f; 
    public PlayerMovement playerMovement;
    private void Start()
    {
        MoveToRandomX();
    }

    private void Update()
    {
        //moves down
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        //Check if the spike is at the target x position
        if (Mathf.Approximately(transform.position.x, transform.GetComponent<FallingSpike>().targetX))
        {
            //Drop the spike down
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }

    }

    float targetX;

    void MoveToRandomX()
    {   
        //Set a random target x position near player
        targetX = Random.Range(playerMovement.getXPos() - 2f, playerMovement.getXPos() + 2f);
        Debug.Log(targetX);
        transform.position = new Vector2(targetX, maxY);
    }

    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerMovement>().Hit(20);
            Debug.Log("hit");
        }
        if (other.gameObject.CompareTag("Enemy")) {
            other.gameObject.GetComponent<EnemyController>().Hit(15);
        }
        Destroy(gameObject);
    }
}