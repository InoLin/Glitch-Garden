using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfBGM : MonoBehaviour
{
    public AudioClip BGM;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeSelfBGM()
    {
        FindObjectOfType<SoundLoader>().ChangeBGM(BGM);
    }
}
