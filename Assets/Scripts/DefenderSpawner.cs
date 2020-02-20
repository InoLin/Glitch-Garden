using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A.滑鼠點擊生成防禦者
//B.獲取點擊到的世界座標
//C.點到的座標即生成防禦者
//D.確保在方格內點擊能將防守者生成在框內並在正確的座標上
//E.將GameObject型態改成Defender，因之前沒有Defender腳本，所以沒有Defender型態，只好用GameObject
//F.讓外部告知此腳本要生成哪個防禦者的方法
//G.判斷是否有足夠星數可消費，如有則可生成防禦者
//H.如果要放置防禦者的方格內已有防禦者則不能生成新的防禦者
//I.整理防禦者讓防禦者可生成在parent空物件底下
//J.生成防禦者出生特效，音效直接綁在Prefab裡面
//K.防守者被創建後重跑按鈕的CD時間(跟DefenderButton合作完成)


public class DefenderSpawner : MonoBehaviour
{
    Defender defender; //A.存放防禦者 //E.將GameObject型態改成Defender，並去除SerializeField
    GameObject defenderParent; //I.
    const string DEFENDER_RARENT_NAME = "Defenders"; //I.應該是避免打錯用的
    private Vector2 theMostLeftDownPos = new Vector2(-5.92f, -2.96f);
    private float perUnitLength = 1.48f;
    public GameObject bornVFX;
    [HideInInspector] public DefenderButton defenderButton; //K.


    private void Start()
    {
        CreateDefenderParent(); //I.執行生成DefenderParent的方法
    }

    

    //檢查
    //放置防禦者
    //存入陣列

    //A.滑鼠點擊方法
    private void OnMouseDown()
    {
        //C.把獲取的網格座標傳入，並執行生成防禦者方法
        //SpawnDefender(GetSquareClicked()); //G.因SpawnDefender成為AttemptToPlaceDefenderAt方法的一部分，所以改寫
        AttemptToPlaceDefenderAt(GetSquareClicked()); //G.執行方法
    }


//B.獲取點擊到的世界座標
    private Vector2 GetSquareClicked()
    {
        //B.點擊座標
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        
        //B.將點擊座標轉換成世界座標
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        
        //D.為確保防守者不會在點擊框外生成而宣告的調整後的世界座標
        Vector2 revisedWorldPos = new Vector2(worldPos.x + perUnitLength / 2, worldPos.y + perUnitLength / 2);
        
        //D.將調整後世界座標傳給網格座標
        Vector2 gridPos = SnapToGrid(revisedWorldPos);

        return gridPos;
    }

    //D.確切防守者的生成座標
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = practicalPosX(rawWorldPos.x);
        float newY = practicalPosY(rawWorldPos.y);
        Vector2 practicalPos = new Vector2(newX, newY);

        return practicalPos;
    }

    //D.確切防守者在X軸的生成點
    private float practicalPosX(float rawX)
    {
        int unitAmount; //D.單位數，必須為整數，數量沒有浮點數
        float totalLength; //D.總長
        float practicalPosX; //D.確切X的點

        unitAmount = (int)((rawX - theMostLeftDownPos.x) / perUnitLength);
        totalLength = unitAmount * perUnitLength;
        practicalPosX = totalLength + theMostLeftDownPos.x;
        return practicalPosX;
    }

    //D.確切防守者在Y軸的生成點
    private float practicalPosY(float rawY)
    {
        int unitAmount;
        float totalLength;
        float practicalPosY;

        unitAmount = (int)((rawY - theMostLeftDownPos.y) / perUnitLength);
        totalLength = unitAmount * perUnitLength;
        practicalPosY = totalLength + theMostLeftDownPos.y;
        return practicalPosY;
    }

    //A.生成防禦者方法
    //C.給要輸入的座標Vector2 worldPos
    private void SpawnDefender(Vector2 roundedPos)
    {
        //E.將GameObject型態改成Defender
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
        //J.生成防禦者出生特效
        Instantiate(bornVFX, roundedPos, Quaternion.identity);
        //I.把新生防禦者變成defenderParent的子物件
        newDefender.transform.parent = defenderParent.transform;
    }

    //F.讓外部告知此腳本要生成哪個防禦者的方法
    public void SetSelectedDefender (Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    //G.判斷是否有足夠星數可消費，如有則可生成防禦者
    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        //G.因要調用StarDisplay的方法HaveEnoughStars所以要先存取
        var StarDisplay = FindObjectOfType<StarDisplay>();
        //G.存取防禦者的生產成本
        int defenderCost = defender.GetStarCost();

        //G.如有足夠星數
        if (StarDisplay.HaveEnoughStars(defenderCost) && defenderButton.currentSpawnDelayTime <= 0)
        {
            SpawnDefender(gridPos); //G.生成防禦者
            StarDisplay.SpendStars(defenderCost); //G.扣除此防禦者要消耗的星數
            defenderButton.currentSpawnDelayTime = defenderButton.spawnDelayTime; //K.按鈕CD重置
            defenderButton = null; //K.清空，避免以為當前沒選到防守者而誤點
        }
    }

    //I.生成DefenderParent的方法
    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_RARENT_NAME); //I.先用找的
        if (!defenderParent) //I.如果找不到
        {
            defenderParent = new GameObject(DEFENDER_RARENT_NAME); //I.用生的
        }
    }

    
}
