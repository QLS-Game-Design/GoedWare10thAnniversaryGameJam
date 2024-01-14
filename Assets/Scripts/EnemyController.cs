using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int currHealth;
    public int maxHealth;
    public float thrust;
    Rigidbody2D rb2d;
    private float time;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currHealth = maxHealth;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        player  = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    public void Hit(int damage) {
        currHealth -= damage;
        Invoke("push", 0.3f);
        if (currHealth <= 0) {
            player.GetComponent<PlayerMovement>().damageBuff++;
            player.GetComponent<PlayerMovement>().maxHealth += player.GetComponent<PlayerMovement>().damageBuff*3;
            player.GetComponent<PlayerMovement>().currHealth += player.GetComponent<PlayerMovement>().damageBuff*3;
            Destroy(gameObject);
        }
    }

    private void push() { 
        if (player.GetComponent<PlayerMovement>().spriteRenderer.flipX == true) {
            rb2d.AddForce(new Vector2(1, 0)*thrust, ForceMode2D.Impulse);
        } else {
            rb2d.AddForce(new Vector2(-1, 0)*thrust, ForceMode2D.Impulse);
        }
    }
}
