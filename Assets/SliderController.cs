using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderController : MonoBehaviour
{
    // Reference to the solar system parent object
    public GameObject solarSystem;
    public TextMeshProUGUI textMeshPro;
    public string onChangeFunctionCallName;


    // Reference to the slider
    private Slider slider;

    private void Start()
    {
        // Get reference to the Slider component
        slider = GetComponent<Slider>();
        
        // Add listener for value changes
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        OnSliderValueChanged(slider.value);
    }

    private void OnSliderValueChanged(float value)
    {
        solarSystem = GameObject.FindWithTag("SolarSystem");
        textMeshPro.text = value.ToString();

        if (solarSystem != null){
            // Find all planets in the solar system
            RotateObject[] planets = solarSystem.GetComponentsInChildren<RotateObject>();

            // Call the function on each planet
            foreach (RotateObject planet in planets)
            {
                // Call the function by name using reflection
                planet.SendMessage(onChangeFunctionCallName, value, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    
}