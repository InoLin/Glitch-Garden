using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //H.
using UnityEngine.Audio; //E.

//有人提過調整音量大小可以用AudioListener的數值來做
//A.調整音量功能
//B.儲存及跳出Options畫面功能(調完音量後需要跳出)
//C.恢復默認設定的方法
//D.調整難度功能
//----------以下為youtube影片教學--------------
//E.音量調整
//F.Graphics設定
//G.全螢幕設定
//H.解析度設定
//I.bool轉型int的方法，為解決PlayerPrefs無法直接存取bool而產生
//J.int轉型bool的方法

public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider; //A.
    public float defaultVolume = 0.8f; //A.
    public Slider difficultySlider; //D.
    public float defaultDifficulty; //D.

    const string VOLUME_KEY = "volume"; //E.
    public AudioMixer audioMixer; //E.
    public Slider soundSlider; //E.

    const string FULLSCREEN_KEY = "fullscreen"; //G.
    public Toggle fullscreenToggle; //G.

    const string GRAPHICS_KEY = "graphics"; //F.
    public Dropdown graphicsDropdown; //F.

    public Dropdown resolutionDropdown; //H.記得要把resolutionDropdown拖曳進來
    Resolution[] resolutions; //H.

    void Start()
    {
        soundSlider.value = PlayerPrefs.GetFloat(VOLUME_KEY); //E.

        fullscreenToggle.isOn = intToBool(PlayerPrefs.GetInt(FULLSCREEN_KEY)); //G. //J.

        graphicsDropdown.value = PlayerPrefs.GetInt(GRAPHICS_KEY); //F.

        InitiateResolutions(); //H.

        volumeSlider.value = PlayerPrefsController.GetMasterVolume(); //A
        difficultySlider.value = PlayerPrefsController.GetDifficulty(); //D.
    }

    void Update()
    {
        /*
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
        */
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

    //E.
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat(VOLUME_KEY, volume);
        audioMixer.SetFloat(VOLUME_KEY, Mathf.Log10(volume) * 20);
    }

    //F.
    public void SetGraphics(int graphicsIndex)
    {
        PlayerPrefs.SetInt(GRAPHICS_KEY, graphicsIndex);
        QualitySettings.SetQualityLevel(graphicsIndex);
    }

    //G.
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt(FULLSCREEN_KEY, boolToInt(isFullscreen)); //I.
    }

    //I.
    int boolToInt(bool val)
    {
        if (val) return 1;
        else return 0;
    }

    //J.
    bool intToBool(int val)
    {
        if (val != 0) return true;
        else return false;
    }

    //H.
    public void InitiateResolutions()
    {
        resolutions = Screen.resolutions; //把所有螢幕支援的解析度存進resolutions陣列
        resolutionDropdown.ClearOptions(); //清空resolutionDropdown所有options
        List<string> options = new List<string>(); //創建一新options的List，型態為string

        int currentResolutionIndex = 0; //宣告當前解析度索引值為0
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //宣告option型態為string，將螢幕的長x寬存入
            options.Add(option); //將存好長寬的option加入options的List

            if (resolutions[i].width == Screen.currentResolution.width && //如果當前螢幕的解析度的寬等於resolutions[i]的寬，且
               resolutions[i].height == Screen.currentResolution.height)  //如果當前螢幕的解析度的高等於resolutions[i]的高
            {
                currentResolutionIndex = i; //將i賦予當前解析度的索引值
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //H.
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
