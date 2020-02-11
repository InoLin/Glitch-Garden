using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A.讓拋射物移動
//B.執行扣血系統
//C.打到敵人後摧毀黃瓜

public class Mover : MonoBehaviour
{
    [SerializeField] float fireSpeed = 2; //A.
    [SerializeField] float damage = 50f; //B.扣血量


    void Start()
    {
        
    }

    void Update()
    {
        //A.讓拋射物移動
        transform.Translate(Vector2.right * fireSpeed * Time.deltaTime);
    }

    //B.黃瓜跟蜥蜴碰撞後銷毀
    //B.要在inspector把Rigidbody的BodyType改成Kinematic
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>(); //B.將碰到的東西的血量存入
        var attacker = otherCollider.GetComponent<Attacker>(); //C.存放敵人

        if(health && attacker)
        {
            health.DealDamage(damage); //B.處理扣血的工作
            Destroy(gameObject); //C.摧毀黃瓜物件
        }

    }
}
