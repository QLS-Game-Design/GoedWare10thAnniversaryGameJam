using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int currHealth;
    public healthBar madnessBar;
    private int currentmad
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {   
        if (currHealth <= 0) {
            Destroy(gameObject);
            madnessBar.SetMadness(0);
        }
    }

    public void Hit(int damage) {
        currHealth -= damage;
    }
}