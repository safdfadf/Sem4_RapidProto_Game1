using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public TextMeshProUGUI sliderValue;
    public Slider barSlider;

    [SerializeField]
    private float speed;
    public bool isOsilating = true;

    private void Update()
    {
        if (isOsilating)
        {
           
            barSlider.value = Mathf.PingPong(Time.time * speed, 1);// Ocilates bars value between 0 To 100
            //SliderValueDisplay();
        }
       
    }
    public void SliderValueDisplay()
    {
        Debug.Log("Slider value displayed");
        sliderValue.text = (barSlider.value * 100).ToString();
    }
}



