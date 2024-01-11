using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private bool iin;
    Collider2D other;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (iin) {
            other.GetComponent<EnemyController>().Hit(damage);
            Debug.Log("Hit");
        }
    }
}
