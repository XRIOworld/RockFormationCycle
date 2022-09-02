using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    //if you want the healthbar fade to gradient
    //public Gradient gradient;
    //public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        //full health would be green
        //fill.color = gradient.Evaluate(1f);
    }

    //create a function to control the health
    public void SetHealth(int health)
    {
        slider.value = health;
        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}