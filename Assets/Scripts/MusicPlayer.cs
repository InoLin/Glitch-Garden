using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//有人提過調整音量大小可以用AudioListener的數值來做
//A.調整音量功能
//B.切換場景有綁這script的物件不會被清除

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        DontDestroyOnLoad(this); //B.
        audioSource = GetComponent<AudioSource>(); //A.
        audioSource.volume = PlayerPrefsController.GetMasterVolume(); //A.
    }

    //A.給輸入值來控制audioSource的volume的方法
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
