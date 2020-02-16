using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A.獎盃用來增加星數的方法，要在Animation增加event來使用此方法
//B.取得星數的方法

//B.設置哪個攻擊者spawner是哪個防禦者的目標的方法
//C.判斷通道上是否有敵人

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;
    private Animator animator; //D.宣告m_Animator
    AttackerSpawner myLaneSpawner; //B.

    private void Start()
    {
        //B.執行設置哪個攻擊者spawner是哪個防禦者的目標的方法
        SetLaneSpawner();
        //D.獲取Animator的Component
        animator = GetComponent<Animator>();
    }

    //A.
    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    //B.
    public int GetStarCost()
    {
        return starCost;
    }

    //C.執行判斷通道上是否有敵人
    private void Update()
    {
        
    }

    //B.設置哪個攻擊者spawner是哪個防禦者的目標的方法
    public void SetLaneSpawner()
    {
        //B.將場上的攻擊者生成池存入陣列
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            //B.攻擊者與防禦者的Y值照講相同，不過作者怕電腦計算失誤，所以用兩邊Y值相減小於一個極小浮點數來判斷
            bool IsCloseEnough =
                (Mathf.Abs(spawner.transform.position.y - transform.position.y)
                <= Mathf.Epsilon);

            //B.如Y值夠近代表在同一通道上，將探訪到的spawner設置為目標spawner也就是myLaneSpawner
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    //C.判斷通道上是否有敵人
    public bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //H.播放受擊動畫的方法
    public void BeingHit()
    {
        animator.SetTrigger("isBeingHit");
    }

    //I.播放死亡動畫的方法
    public void IsDead()
    {
        animator.SetTrigger("isDead");
    }
}
