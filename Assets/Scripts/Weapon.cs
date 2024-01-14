using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private bool iin;
    Collider2D other;

    public float cooldown = 1.0f;
    private float time;
    public bool canHit;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        canHit = true;
        cooldown = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {   
        if (canHit == false) {
            time += Time.deltaTime;
            if (time > cooldown) {
                canHit = true;
                time = 0.0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            other = collision;
            iin = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        iin = false;
    }

    public void attack(int damage) {
        if (iin && canHit) {
            other.GetComponent<EnemyController>().Hit(damage);
            Debug.Log("Hit");
        }
    }
}
