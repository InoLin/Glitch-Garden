using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//A.宣告名為stars的變數，並獲取Star Text物件裡名為Text的組件
//B.更新stars的方法
//C.增加星數方法
//D.減少星數方法
//E.判斷星數是否足夠方法
//F.

public class StarDisplay : MonoBehaviour
{
    public int stars = 100; //A.
    TextMeshPro starText; //A.

    void Start()
    {
        starText = GetComponent<TextMeshPro>(); //A.獲取名為Text的組件
        UpdateDisplay(); //B.執行更新stars的方法
        StartCoroutine(AutoAddStars()); //F.
    }

    //B.更新stars的方法
    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    //C.增加星數方法
    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    //D.減少星數方法
    public void SpendStars(int amount)
    {
        //D.要有足夠星數才能被扣除
        if(stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }

    //E.判斷星數是否足夠方法
    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

    //F.
    IEnumerator AutoAddStars()
    {
        while (true)
        {
            yield return new WaitForSeconds(6);
            AddStars(25);
        }
    }

    /*
    public int GetStarsCount()
    {
        return stars;
    }
    */

}
