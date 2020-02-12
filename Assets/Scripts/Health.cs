using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A.血量及扣血系統
//B.敵人死後生成死掉特效
//C.一秒後銷毀VFX物件
//D.當攻擊者死亡後減去攻擊者數量

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f; //A.血量
    //B.要去VFX的prefab調整Renderer-->sorting layer，不然可能會看不見
    //public GameObject deathVFX; //B.存放特效
    public GameObject hitVFX;
    [SerializeField] LevelController levelController; //D.存放攻擊者計數器

    void Start()
    {
        levelController = FindObjectOfType<LevelController>(); //D.尋找場上有LevelController的物件
    }

    //A.扣血系統
    public void DealDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            TriggerHitVFX();
            Destroy(gameObject);
        }
        else
        {
            TriggerHitVFX();
        }
    }

    /*
    //B.生成特效方法
    private void TriggerDeathVFX()
    {
        if(!deathVFX) { return; } //B.如果沒特效就繼續執行(不管的意思)
        //C.這個deathVFXObject是為了能夠銷緩才宣告的
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f); //C.一秒後銷毀VFX物件
    }
    */

    private void TriggerHitVFX()
    {
        if (!hitVFX) { return; }
        GameObject hitVFXObject =  Instantiate(hitVFX, transform.position, Quaternion.identity);
        Destroy(hitVFXObject, 0.33f);
    }

}
