using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//A.滑鼠點擊圖示，顏色變白
//B.沒被點到的防守者按鈕會自動變回黑色
//C.將指定好的prefab傳給DefenderSpawner
//D.按鈕顯示防禦者成本的功能

public class DefenderButton : MonoBehaviour
{
    //C.存放defenderPrefab，要到inspector指定
    public Defender defenderPrefab;

    private void Start()
    {
        LabelButtonWithCost(); //D.
    }

    //A.
    private void OnMouseDown()
    {
        //B.沒被點到的會自動變回黑色
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color32(41, 41, 41, 255);
        }

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
}
