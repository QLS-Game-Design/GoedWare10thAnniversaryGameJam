using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentMadness;
    public Madness
    void Start()
    {
        currentMadness = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void gainMadness(int madness) {
        currentMadness += madness;
    }
}
