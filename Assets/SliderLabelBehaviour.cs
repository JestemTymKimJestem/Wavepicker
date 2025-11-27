using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderLabelBehaviour : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Slider slider; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void updateTextFromSlider()
    {
        text.text=slider.value.ToString("F2");
    }
    // Update is called once per frame
    void Update()
    {
        updateTextFromSlider();
    }
}
