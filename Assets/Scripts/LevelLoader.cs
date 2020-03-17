using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//A.獲取場景編號跟執行等待
//B.載入下個場景
//C.載入失敗場景
//D.重啟當前場景
//E.載入開頭主畫面
//F.將遊戲執行速度設為1，因在LevelController如遊戲失敗，會將遊戲執行速度設為0
//G.結束遊戲的方法
//H.載入Options畫面的方法

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4; //A.等待時間4秒
    int currentSceneIndex; //A.當前場景編號

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //A.獲取當前場景的編號
        if(currentSceneIndex == 0) //A.如果當前場景編號為0
        {
            StartCoroutine(WaitForTime()); //A.執行等待
        }
    }

    void Update()
    {
        
    }

    //A.等待的方法
    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene(); //B.執行載入下個場景
    }

    //B.載入下個場景的方法
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene("Level 01");
    }

    public void LoadSecondScene()
    {
        SceneManager.LoadScene("Level 02");
    }

    public void LoadThirdScene()
    {
        SceneManager.LoadScene("Level 03");
    }

    //C.載入失敗場景的方法
    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    //D.重啟當前場景
    public void RestartScene()
    {
        Time.timeScale = 0; //F.
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("Level Select Screen");
    }

    //E.載入開頭主畫面
    public void LoadMainMenu()
    {
        Time.timeScale = 1; //F.
        SceneManager.LoadScene("Start Screen");
    }

    //G.結束遊戲的方法
    public void QuitGame()
    {
        Application.Quit();
    }

    //H.載入Options畫面的方法
    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void LoadTalkScene()
    {
        SceneManager.LoadScene("Talk Screen 01");
    }
}
