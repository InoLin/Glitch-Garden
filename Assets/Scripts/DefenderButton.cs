using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//A.滑鼠點擊圖示，顏色變白
//B.沒被點到的防守者按鈕會自動變回黑色
//C.將指定好的prefab傳給DefenderSpawner
//D.按鈕顯示防禦者成本的功能
//E.如星數不夠則將按鈕變暗
//F.防守者被創建後重跑按鈕的CD時間(跟DefenderSpawner合作完成)
//G.點創角按鈕產生一角色圖片跟隨滑鼠的功能
//H.將指定的cursor圖案給BattleSceneController的子物件Cursor並顯示
//I.如滑鼠上已有cursor圖案跟隨，點CD未完成的按鈕可以取消cursor圖案

public class DefenderButton : MonoBehaviour
{
    //C.存放defenderPrefab，要到inspector指定
    public Defender defenderPrefab;
    private int currentTotalStarsCount; //E.
    private int spawnDefenderCost; //E.
    [HideInInspector]  public float spawnDelayTime; //F.
    [HideInInspector]  public float currentSpawnDelayTime; //F.
    private Image waitingImage; //F.
    public GameObject defenderCursor; //G.
    public BattleSceneController battleSceneController;

    private void Start()
    {
        LabelButtonWithCost(); //D.
        spawnDefenderCost = defenderPrefab.GetStarCost();
        waitingImage = transform.GetChild(0).gameObject.transform.GetChild(2).GetComponent<Image>();
        spawnDelayTime = defenderPrefab.spawnDelayTime; //F.
        currentSpawnDelayTime = 0;//F.
    }

    private void Update()
    {
        ChangeColor(); //E.
        currentSpawnDelayTime -= Time.deltaTime; //F.
        waitingImage.fillAmount = currentSpawnDelayTime / spawnDelayTime; //F.

    }

    //A.
    private void OnMouseDown()
    {
        if (!IsClickable()) //I.
        {
            HideSpecificCursor(); //I.
            FindObjectOfType<DefenderSpawner>().SetDefenderNull();
        }
        else
        {
            FindObjectOfType<DefenderSpawner>().defenderButton = this; //F.
            ShowSpecificCursor(); //H.
            //FindObjectOfType<DefenderSpawner>().SetDefenderNull();
            FindObjectOfType<DefenderRemoverButton>().SetIsRemoverOnFalse();
            //C.點擊到的圖標，因已把prefab指定好了，所以只要點到就知道要生成哪個prefab
            FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
        }

        transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.white;
    }

    //D.
    private void LabelButtonWithCost()
    {
        Text costText = this.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        if (!costText)
        {
            Debug.LogError(name + "has no cost text, add some!");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    //E.如星數足夠且按鈕CD完成
    private void ChangeColor()
    {
        currentTotalStarsCount = FindObjectOfType<StarDisplay>().stars;

        if (IsClickable())
        {
            transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.white;
        }
        else
        {
            transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color32(100, 100, 100, 255);
        }
    }

    private bool IsClickable()
    {
        if (spawnDefenderCost <= currentTotalStarsCount && currentSpawnDelayTime <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //H.
    private void ShowSpecificCursor()
    {
        //將按鈕的defenderCursor的sprite傳給實際的sprite
        battleSceneController.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite =
            defenderCursor.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
        //開啟實際的sprite
        battleSceneController.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    //I.
    private void HideSpecificCursor()
    {
        battleSceneController.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
