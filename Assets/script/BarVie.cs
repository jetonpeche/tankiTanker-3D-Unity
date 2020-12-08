using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class BarVie : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image vie;

    public void SetVieMax(int _vie)
    {
        slider.maxValue = _vie;
        slider.value = slider.maxValue;

        vie.color = gradient.Evaluate(1f);
    }

    public void SetVie(int _vie)
    {
        slider.value = _vie;
        vie.color = gradient.Evaluate(slider.normalizedValue);
    }
}
