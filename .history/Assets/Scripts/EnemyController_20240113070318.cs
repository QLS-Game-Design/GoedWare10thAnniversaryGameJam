using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int currHealth;
    public healthBar madnessBar;
    private int currentMadness;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {   currentMadness = madnessBar.getMadness();
        if (currHealth <= 0) {
            Destroy(gameObject);
            madnessBar.SetMadness(currentMadness +);
        }
    }

    public void Hit(int damage) {
        currHealth -= damage;
    }
}
