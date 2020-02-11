using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//A.Tooltip用法
//B.讓Slider的滑桿隨著時間移動
//C.如時間到了則告知LevelController關卡結束
//D.讓Update只執行一次用

public class GameTimer : MonoBehaviour
{
    //A.Tooltip當滑鼠移動到inspector的levelTime參數欄位上時，會顯示說明文字。
    [Tooltip("Our level timer in SECONDS")]
    public float levelTime = 10;
    //D.讓Update只執行一次用，需要Update來判斷時間是否到了，但又需要只執行一次
    bool triggerdLevelFinished = false;

    void Update()
    {
        //D.如果triggerdLevelFinished為true則之後的都不用做，所以...
        if (triggerdLevelFinished) { return; }
        //B.timeSinceLevelLoad為從場景被加載後經過的時間，以秒為單位
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        //B.timeSinceLevelLoad因隨時間增加所以最後一定會大於levelTime
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            //C. //D.這行才會只執行一次，即使是在Update底下
            FindObjectOfType<LevelController>().LevelTimerFinished();
            //D.將triggerdLevelFinished變為true，使Update想重複執行，但會被第一個if擋下來
            triggerdLevelFinished = true;
        }
    }

    
}
