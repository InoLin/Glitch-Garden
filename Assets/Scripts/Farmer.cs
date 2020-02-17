using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    public GameObject credits, gun; //A.存放拋射物、發射位置
    private Animator animator; //D.宣告m_Animator
    GameObject creditsParent; //E.
    const string CREDITS_PARENT_NAME = "credits"; //E.
    public float fireDelayTime = 1f; //F.
    private float currentFireDelayTime = 0f; //F.

    private void Start()
    {
        CreateCreditsParent(); //E.執行生成projectileParent的方法
        animator = GetComponent<Animator>(); //D.獲取Animator的Component
    }

    private void Update()
    {
        //F.讓currentFireDelayTime隨著時間而增加
        currentFireDelayTime += Time.deltaTime;
        //B.如果攻擊者在通道上 //F.而且currentFireDelayTime須超過延遲時間
        if (currentFireDelayTime >= fireDelayTime)
        {
            //D.播攻擊動畫，IsAttack是在動畫機裡設置的變數，名稱需完全一樣
            animator.SetBool("isAttacking", true);
            //F.每次攻擊完需減掉延遲時間
            currentFireDelayTime = currentFireDelayTime - fireDelayTime;
        }
    }

    //A.產生拋射物的方法
    public void fire()
    {
        //E.
        GameObject newCredits =
            Instantiate(credits, gun.transform.position, gun.transform.rotation);
        //E.把新生拋射物變成projectileParent的子物件
        newCredits.transform.parent = creditsParent.transform;
    }

    //E.生成projectileParent的方法
    private void CreateCreditsParent()
    {
        creditsParent = GameObject.Find(CREDITS_PARENT_NAME);
        if (!creditsParent)
        {
            creditsParent = new GameObject(CREDITS_PARENT_NAME);
        }
    }

    public void TurnOffAttackAnimation()
    {
        animator.SetBool("isAttacking", false);
    }
}
