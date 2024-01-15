using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class MadnessBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    private void Start() {
        slider.maxValue = 100;
        slider.value = 0;
    }

    public void setMaxMadness(int max) {
        slider.maxValue = max;
    }

    public void SetMadness(int madness){
        slider.value = madness;
    }

    public int getMadness() {
        return (int)(slider.value);
    }
}
