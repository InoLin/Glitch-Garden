using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoader : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void turnDownVolume()
    {
        audioSource.volume = 0.1f;
    }

    public void ChangeBGM(AudioClip BGM)
    {
        audioSource.Stop();
        audioSource.clip = BGM;
        audioSource.Play();
        Debug.Log("改成boss音樂");
    }
}
