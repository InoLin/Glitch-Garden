using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //將被碰到的gameObject存入
        GameObject otherObject = otherCollider.gameObject;

        //如碰到的是石頭
        if (otherObject.GetComponent<Stone>())
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("JumpTrigger");
        }
        //或者如碰到的是防禦者
        else if (otherObject.GetComponent<Defender>())
        {
            //執行攻擊方法
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
