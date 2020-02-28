using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource buttonAudio;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void HoverSound()
    {
        buttonAudio.PlayOneShot(hoverSound);
    }

    public void ClickSound()
    {
        buttonAudio.PlayOneShot(clickSound);
    }


}
