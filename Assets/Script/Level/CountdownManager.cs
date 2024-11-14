using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownManager : MonoBehaviour
{

    public float Countdown;

    public float CountdownCurrent;

    public TextMeshProUGUI Wave;

    public Slider CountdownSlider;

    public int WaveIndex = 1;

    public static Action OnWaveUp;

    // Start is called before the first frame update
    void Start()
    {
        CountdownSlider.maxValue = Countdown;
    }

    // Update is called once per frame
    void Update()
    {
        CountdownSlider.value = CountdownCurrent;

        if(CountdownCurrent <= 0)
        {
            if(WaveIndex < 3)
            {
                WaveIndex += 1;
                Countdown += 180;
            }
            
            Wave.text = "Wave "+ WaveIndex;
            OnWaveUp?.Invoke();
           
            CountdownCurrent = Countdown;
            CountdownSlider.maxValue = Countdown;
        } else
        {
            CountdownCurrent -= Time.deltaTime;
        }
    }
}
