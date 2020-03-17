using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFuncionChanger01 : MonoBehaviour
{
    public int levelNumber;
    public LevelSelectController levelSelectController;

    void Start()
    {
        levelNumber = 0;
        levelNumber = levelSelectController.GetLevelPassedInt();
        
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
