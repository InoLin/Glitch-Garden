using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 * 功能:
 * 過關後解鎖下個關卡的按鈕，未過關不能點擊
 * 按Q可重置LEVEL_PASSED_KEY的PlayerPrefs
 * 需跟LevelController配合
 * 
 * A.依照levelPassed決定按鈕是否啟用
 * B.按Q重置LEVEL_PASSED_KEY的PlayerPrefs
*/

public class LevelSelectController : MonoBehaviour
{
    public Button levelButton02;
    public Button levelButton03;
    public int levelPassed; //A.過了幾關，原本為0
    const string LEVEL_PASSED_KEY = "levelPassed"; //A.存放levelPassed的PlayerPrefs

    void Start()
    {
        levelPassed = PlayerPrefs.GetInt(LEVEL_PASSED_KEY); //A.每次重開都讀取levelPassed的PlayerPrefs

        levelButton02.interactable = false;
        levelButton03.interactable = false;
        levelButton02.GetComponent<AudioSource>().enabled = false;
        levelButton03.GetComponent<AudioSource>().enabled = false;

        switch (levelPassed) //A.依照levelPassed決定按鈕是否啟用
        {
            case 0:
                levelButton02.interactable = false;
                levelButton03.interactable = false;
                levelButton02.GetComponent<AudioSource>().enabled = false;
                levelButton03.GetComponent<AudioSource>().enabled = false;
                break;
            case 1:
                levelButton02.interactable = true;
                levelButton02.GetComponent<AudioSource>().enabled = true;
                break;
            case 2:
                levelButton02.interactable = true;
                levelButton03.interactable = true;
                levelButton02.GetComponent<AudioSource>().enabled = true;
                levelButton03.GetComponent<AudioSource>().enabled = true;
                break;
        }
    }

    void Update()
    {
        //B.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            resetPlayerPrefs();
        }
    }

    public void resetPlayerPrefs()
    {
        levelButton02.interactable = false;
        levelButton03.interactable = false;
        levelButton02.GetComponent<AudioSource>().enabled = false;
        levelButton03.GetComponent<AudioSource>().enabled = false;
        PlayerPrefs.DeleteKey(LEVEL_PASSED_KEY);
    }

    public int GetLevelPassedInt()
    {
        return PlayerPrefs.GetInt(LEVEL_PASSED_KEY);
    }

    public void SetLevelPassedInt(int volume)
    {
        PlayerPrefs.SetInt(LEVEL_PASSED_KEY, volume);
    }
}
