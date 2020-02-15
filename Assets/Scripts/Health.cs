﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A.血量、扣血系統、播放死亡動畫
//C.一秒後銷毀VFX物件
//D.當攻擊者死亡後減去攻擊者數量
//H.播放受擊動畫
//I.播放死亡動畫的方法

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f; //A.血量
    //B.要去VFX的prefab調整Renderer-->sorting layer，不然可能會看不見
    [SerializeField] LevelController levelController; //D.存放攻擊者計數器
    private Animator animator; //B.

    void Start()
    {
        animator = GetComponent<Animator>(); //B.
        levelController = FindObjectOfType<LevelController>(); //D.尋找場上有LevelController的物件
    }

    //A.扣血系統
    public void DealDamage(float damage)
    {
        health -= damage;
        if (GetComponent<Attacker>())
        {
            GetComponent<Attacker>().BeingHit();
        }
        else if (GetComponent<Defender>())
        {
            GetComponent<Defender>().BeingHit();
        }

        if (health <= 0)
        {
            if (GetComponent<Attacker>())
            {
                GetComponent<Attacker>().IsDead();
            }
            else if (GetComponent<Defender>())
            {
                GetComponent<Defender>().IsDead();
            }
        }
    }

    
}
