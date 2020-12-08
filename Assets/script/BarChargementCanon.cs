using UnityEngine;
using UnityEngine.UI;

public class BarChargementCanon : MonoBehaviour
{
    private Slider slider;
    private float vitesseLerp;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        Initialisation();
    }

    private void Update()
    {
        vitesseLerp = 2 * Time.deltaTime;

        if (slider.value != slider.maxValue)
            RechargementCanon();
    }

    private void Initialisation()
    {
        slider.maxValue = 100;
        slider.value = slider.maxValue;
    }

    private void RechargementCanon()
    { 
        slider.value = Mathf.Lerp(slider.value, slider.maxValue + 4, vitesseLerp); 
    }

    public void CanonDecharger()
    {
        slider.value = 0;
    }


}
