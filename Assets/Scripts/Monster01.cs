﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster01 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //A.將被碰到的gameObject存入
        GameObject otherObject = otherCollider.gameObject;

        //A.如碰到的是防禦者
        if (otherCollider.GetComponent<Defender>())
        {
            //A.執行攻擊方法
            GetComponent<Attacker>().Attack(otherObject);
        }

        //B.如果碰到的是飛行道具
        if (otherCollider.GetComponent<Mover>())
        {
            //B.執行受擊方法
            GetComponent<Attacker>().BeingHit();
        }
    }
}
