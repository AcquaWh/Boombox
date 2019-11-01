using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObj : MonoBehaviour {

    Vector3 initialScale;

    [SerializeField]
    float scaleFactor;

    [SerializeField]
    public enum FreqType
    {
        Low,
        Mid,
        High
    }

    float freq;

    [SerializeField]
    FreqType freqType;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {

        switch(freqType)
        {
            case FreqType.Low:
                freq = AudioVisualizer.instance.LowFreq;
                break;
            case FreqType.Mid:
                freq = AudioVisualizer.instance.MidFreq;
                break;
            case FreqType.High:
                freq = AudioVisualizer.instance.HighFreq;
                break;
        }

        Vector3 newScale = new Vector3(freq, freq, freq) * scaleFactor;
        transform.localScale = newScale + initialScale;
    }    
}