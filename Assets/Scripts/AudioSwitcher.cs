using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitcher : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlayFirstAudio()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    void PlaySecondAudio()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }

}
