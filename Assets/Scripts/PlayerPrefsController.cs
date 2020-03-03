using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//有人提過調整音量大小可以用AudioListener的數值來做
//A.跳整主音量的功能製作
//B.調整難度功能製作

public class PlayerPrefsController : MonoBehaviour
{
    
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficuty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;

    //A.設置主音量值的方法
    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.Log("Master volume is out of range");
        }
    }

    //A.獲取主音量值的方法
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    //B.設定難度的方法
    public static void SetDifficulty(float diffculty)
    {
        if(diffculty >= MIN_DIFFICULTY && diffculty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diffculty);
        }
        else
        {
            Debug.LogError("Difficulty setting is not in range.");
        }
    }

    //B.獲取難度的方法
    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
    
}
