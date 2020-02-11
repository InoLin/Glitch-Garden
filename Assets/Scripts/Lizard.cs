using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //B.將被碰到的gameObject存入
        GameObject otherObject = otherCollider.gameObject;

        //B.如碰到的是防禦者
        if (otherCollider.GetComponent<Defender>())
        {
            //B.執行攻擊方法
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
