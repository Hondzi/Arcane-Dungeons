using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Staminabar : MonoBehaviour
{
    public Slider sliders;
    public Gradient gradients;
    public Image fills;


    public void SetMaxStamina(int stamina)
    {
        sliders.maxValue = stamina;
        sliders.value = stamina;

        fills.color = gradients.Evaluate(1f);
    }

    public void SetStamina(int stamina)
    {
        sliders.value = stamina;

        fills.color = gradients.Evaluate(sliders.normalizedValue);

    }
}
