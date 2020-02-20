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

public class DefenderButton : MonoBehaviour
{
    //C.存放defenderPrefab，要到inspector指定
    public Defender defenderPrefab;
    private int currentTotalStarsCount; //E.
    private int spawnDefenderCost; //E.
    public float spawnDelayTime; //F.
    public float currentSpawnDelayTime; //F.
    private Image waitingImage; //F.

    private void Start()
    {
        LabelButtonWithCost(); //D.
        spawnDefenderCost = defenderPrefab.GetStarCost();
        waitingImage = transform.GetChild(0).gameObject.transform.GetChild(2).GetComponent<Image>();
        spawnDelayTime = defenderPrefab.spawnDelayTime; //F.
        currentSpawnDelayTime = spawnDelayTime;//F.
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
        FindObjectOfType<DefenderSpawner>().defenderButton = this; //F.
        transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.white;
        
        //C.點擊到的圖標，因已把prefab指定好了，所以只要點到就知道要生成哪個prefab
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
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

        if (spawnDefenderCost <= currentTotalStarsCount && currentSpawnDelayTime <= 0)
        {
            transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.white;
        }
        else
        {
            transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color32(100, 100, 100, 255);
        }
    }
}
