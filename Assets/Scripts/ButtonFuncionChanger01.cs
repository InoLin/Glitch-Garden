using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * C.第一次遊玩按鈕顯示start，點擊進入對話場景，第一次以後直接進入關卡
 */

public class ButtonFuncionChanger01 : MonoBehaviour
{
    public int levelNumber;
    public LevelSelectController levelSelectController;
    public bool isFirstTimePlay = true; //C.
    public const string IS_FIRST_TIME_PLAY_KEY = "isFirstTimePlay"; //C.

    void Start()
    {
        isFirstTimePlay = intToBool(PlayerPrefs.GetInt(IS_FIRST_TIME_PLAY_KEY)); //C.

        levelNumber = 0;
        levelNumber = levelSelectController.GetLevelPassedInt();

        //C.如果第一次遊玩
        if (isFirstTimePlay)
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "START";
            this.gameObject.GetComponent<Button>().onClick.AddListener(FindObjectOfType<LevelLoader>().LoadTalkScene);
        }
        else
        {
            switch (levelNumber)
            {
                case 0:
                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "LEVEL 1-1";
                    this.gameObject.GetComponent<Button>().onClick.AddListener(FindObjectOfType<LevelLoader>().LoadFirstScene);
                    break;
                case 1:
                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "LEVEL 1-2";
                    this.gameObject.GetComponent<Button>().onClick.AddListener(FindObjectOfType<LevelLoader>().LoadSecondScene);
                    break;
                case 2:
                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "LEVEL 1-3";
                    this.gameObject.GetComponent<Button>().onClick.AddListener(FindObjectOfType<LevelLoader>().LoadThirdScene);
                    break;
            }
        }
    }

    //C.
    public void SetFirstTimePlayKeyTrue()
    {
        PlayerPrefs.SetInt(IS_FIRST_TIME_PLAY_KEY, boolToInt(true));
    }

    //C.
    public void SetFirstTimePlayKeyFalse()
    {
        PlayerPrefs.SetInt(IS_FIRST_TIME_PLAY_KEY, boolToInt(false));
    }

    int boolToInt(bool val)
    {
        if (val) return 1;
        else return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0) return true;
        else return false;
    }

    
}
