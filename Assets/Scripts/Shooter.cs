using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A.產生拋射物(發射黃瓜)
//B.設置哪個攻擊者spawner是哪個防禦者的目標的方法
//C.判斷通道上是否有敵人
//D.讓防守者平時撥idle動畫，要敵人時才撥attack動畫
//E.整理拋射物讓拋射物可生成在parent空物件底下

public class Shooter : MonoBehaviour
{
    public GameObject projectile, gun; //A.存放拋射物、發射位置
    AttackerSpawner myLaneSpawner; //B.
    private Animator m_Animator; //D.宣告m_Animator
    GameObject projectileParent; //E.
    const string PROJECTILE_PARENT_NAME = "Projectiles"; //E.

    private void Start()
    {
        CreateProjectileParent(); //E.執行生成projectileParent的方法
        m_Animator = GetComponent<Animator>(); //D.獲取Animator的Component

        //B.執行設置哪個攻擊者spawner是哪個防禦者的目標的方法
        SetLaneSpawner(); 
    }

    //C.執行判斷通道上是否有敵人
    private void Update()
    {
        //B.如果攻擊者在通道上
        if (IsAttackerInLane())
        {
            //D.播攻擊動畫，IsAttack是在動畫機裡設置的變數，名稱需完全一樣
            m_Animator.SetBool("IsAttack", true);
        }
        else
        {
            //D.播等待動畫
            m_Animator.SetBool("IsAttack", false);
        }
    }
    
    //A.產生拋射物的方法
    public void fire()
    {
        //E.
        GameObject newProjectile = 
            Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        //E.把新生拋射物變成projectileParent的子物件
        newProjectile.transform.parent = projectileParent.transform;
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
                (Mathf.Abs( spawner.transform.position.y - transform.position.y)
                <= Mathf.Epsilon);

            //B.如Y值夠近代表在同一通道上，將探訪到的spawner設置為目標spawner也就是myLaneSpawner
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    //C.判斷通道上是否有敵人
    private bool IsAttackerInLane()
    {
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //E.生成projectileParent的方法
    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }
}
