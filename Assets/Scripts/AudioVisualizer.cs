using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{

    float[] spectrum;
    public float frequency {get; set;}

    float lowFreq;
    float midFreq;
    float highFreq;

    AudioSource music;

    public static AudioVisualizer instance;

    void Start()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        spectrum = new float[256];
        music = GetComponent<AudioSource>();
    }

   void Update()
   {
        music.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            frequency = spectrum[i];

            lowFreq = frequency < 200f ? frequency : lowFreq;
            midFreq = frequency > 200f || frequency <= 5000f ? frequency : midFreq;
            highFreq = frequency > 5000f || frequency < 20000f ? frequency : highFreq;
        }
   }

   public float LowFreq
   {
       get => lowFreq;
   }

   public float MidFreq
   {
       get => midFreq;
   }

   public float HighFreq
   {
       get => highFreq;
   }
}
