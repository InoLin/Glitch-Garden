using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour
{
    public GameObject currentDefenderCursor;

    void Start()
    {
        Instantiate(currentDefenderCursor);
        GameObject.Find("Char01 Cursor(Clone)").transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        GiveMousePosToDefenderCursor();
    }

    public void CreatDefenderCursor()
    {
    }

    //G.
    private void GiveMousePosToDefenderCursor()
    {
        //把滑鼠座標轉螢幕座標並賦予defenderCursor，Z不給大於0的話，圖片會無法顯示
        //x的+20跟y的+70是位置微調，這樣比較好看
        GameObject.Find("Char01 Cursor(Clone)").transform.position =
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + 20, Input.mousePosition.y + 70, 10));
    }

}
