using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoader : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void turnDownVolume()
    {
        GetComponent<AudioSource>().volume = 0.1f;
    }
}
