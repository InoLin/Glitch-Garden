using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A.讓攻擊者能夠移動
//B.攻擊者碰到防禦者會停止移動並撥放攻擊動作
//C.讓攻擊者能攻擊防禦者並執行扣血工作
//D.防禦者死掉後，攻擊者回到走路動畫
//E.讓攻擊者在生成時自動增加攻擊者數量
//F.讓攻擊者在摧毀時自動減少攻擊者數量
//G.
//H.播放受擊動畫
//J.消滅自身的方法
/*
 * 特別記事:
 * H.在做受擊動畫時，原本希望用動畫去做擊退的位移效果，
 * 但執行遊戲時蜥蜴的座標會跑掉，最後改由在Mover做效果，詳情看Mover的D。
 */

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] //A.讓變數在inspector有拉霸
    [SerializeField] float currentSpeed = 0;
    private Animator m_animator; //B.
    private GameObject currentTarget;

    //E.
    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    //F.
    private void OnDestroy()
    {
        //G.下行為原寫法，在console會有NullReferenceException的問題
        //FindObjectOfType<LevelController>().AttackerKilled();
        //G.解決NullReferenceException的問題
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController != null) //G.如果有東西才執行底下那行
        {
            levelController.AttackerKilled();
        }
    }

    void Start()
    {
        m_animator = GetComponent<Animator>(); //B.
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime); //A.攻擊者位移
        UpdateAnimationState(); //D.執行更新動畫的方法
    }

    

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    //B.播放攻擊動畫的方法
    public void Attack(GameObject target)
    {
        m_animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    //C.讓攻擊者能攻擊防禦者並執行扣血工作
    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; } //C.如果沒目標，就繼續
        Health health = currentTarget.GetComponent<Health>(); //C.如果有目標，就尋找看有無Health
        if (health) //C.如果有health
        {
            health.DealDamage(damage); //C.執行扣血
        }
    }

    //D.防禦者死掉後，攻擊者回到走路動畫
    private void UpdateAnimationState()
    {
        if (!currentTarget) //D.如果沒有當前目標
        {
            m_animator.SetBool("isAttacking", false); //D.
        }
    }

    //H.播放受擊動畫的方法
    public void BeingHit()
    {
        m_animator.SetTrigger("isBeingHit");
    }

    //I.播放死亡動畫的方法
    public void IsDead()
    {
        m_animator.SetTrigger("isDead");
    }

    //J.消滅自身的方法
    public void DestroyItself()
    {
        Destroy(gameObject);
    }

    /*
    //B.攻擊者碰到防禦者會停止移動並撥放攻擊動作
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //B.將被碰到的gameObject存入
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.tag == "Stone") //E.如果標籤為石頭
        {
            m_animator.SetTrigger("JumpTrigger"); //E.播放跳躍動畫
        }

        //B.如碰到的是防禦者
        else if (otherCollider.GetComponent<Defender>())
        {
            //B.執行攻擊方法
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
    */


}
