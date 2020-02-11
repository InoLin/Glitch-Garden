using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//有人提過調整音量大小可以用AudioListener的數值來做
//A.調整音量功能
//B.儲存及跳出Options畫面功能(調完音量後需要跳出)
//C.恢復默認的方法
//D.調整難度功能

public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider; //A.
    public float defaultVolume = 0.8f; //A.

    public Slider difficultySlider; //D.
    public float defaultDifficulty; //D.

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume(); //A
        difficultySlider.value = PlayerPrefsController.GetDifficulty(); //D.
    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>(); //A.
        //A.
        if (musicPlayer)
        {
            //A.用滑桿來控制audioSource的volume的值
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found...");
        }
    }

    //B.
    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value); //D.
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    //C.
    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty; //D.
    }
}
