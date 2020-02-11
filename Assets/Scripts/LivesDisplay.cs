using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//A.製作生命次數系統
//B.如果生命小於等於0，載入失敗場景
//C.如果生命小於等於0，開啟失敗UI
//D.讓難度調整滑桿跟牆生命值連動

public class LivesDisplay : MonoBehaviour
{
    //SerializeField] int lives = 5; //D.去掉此行
    [SerializeField] float baseLives = 3; //D.
    [SerializeField] private int damage = 1;
    float lives; //D.
    public Text livesText;

    private void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty(); //D.
        livesText = GetComponent<Text>();
        UpdateLives();
        Debug.Log("Difficulty setting currently is " + PlayerPrefsController.GetDifficulty()); //D.
    }

    //A.更新生命次數文字的方法
    private void UpdateLives()
    {
        livesText.text = "圍牆生命數: " + lives.ToString();
    }

    //A.扣生命次數的方法
    public void TakeLife()
    {
        lives = lives - damage;
        UpdateLives();

        //B.如果生命小於等於0，載入失敗場景
        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition(); //C.
        }
    }
    /*
    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }
    */
}
