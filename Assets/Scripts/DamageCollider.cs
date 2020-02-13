using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A.碰到碰撞體後，扣生命次數
//B.攻擊者碰到collider後被摧毀

public class DamageCollider : MonoBehaviour
{
    //A.碰到碰撞體後，執行扣生命次數
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<Attacker>())
        {
            FindObjectOfType<LivesDisplay>().TakeLife();
        }
        Destroy(otherCollider.gameObject); //B.
    }
}
