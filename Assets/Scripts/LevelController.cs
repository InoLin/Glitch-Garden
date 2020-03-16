using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//A.攻擊者計數器
//B.將關卡結束並停止生成攻擊者
//C.勝利文字
//D.顯示失敗文字，並將遊戲執行速度設為0

public class LevelController : MonoBehaviour
{
    public int numberOfAttackers = 0; //A.攻擊者計數器
    bool levelTimerFinished = false; //A.判斷關卡是否結束
    public GameObject winLabel; //C.
    public GameObject loseLabel; //D.
    [SerializeField] float waitToLoad = 4f; //C.

    private void Start()
    {
        Time.timeScale = 0;
        winLabel.SetActive(false); //C.
        loseLabel.SetActive(false); //D.
    }

    //A.增加攻擊者計數器的方法
    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    //A.減少攻擊者計數器的方法，判斷數量小於0且關卡結束
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition()); //C.
        }
    }
    
    //B.關卡結束，並執行停止生成攻擊者的方法
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
    }

    //C.
    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        FindObjectOfType<SoundLoader>().turnDownVolume();
        yield return new WaitForSeconds(waitToLoad);
        if(SceneManager.GetActiveScene().name == "Level 03")
        {
            FindObjectOfType<LevelLoader>().LoadFirstScene();
        }
        else
        {
            FindObjectOfType<LevelLoader>().LoadNextScene();
        }
    }

    //D.
    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0; //D.將遊戲執行速度設為0
    }

}
