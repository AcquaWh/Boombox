using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;     
 

public class AudioCassette : MonoBehaviour
{
    [SerializeField]
    AudioSource audio;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void StartAudio()
    {
        audio.Play();
    }
}
