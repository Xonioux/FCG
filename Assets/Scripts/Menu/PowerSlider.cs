using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour
{
    public float shotValue;
    private Slider slider;
    public ShootBall sB = null;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        shotValue = sB.powerMultiplier;
        slider.value = shotValue;
    }
}
