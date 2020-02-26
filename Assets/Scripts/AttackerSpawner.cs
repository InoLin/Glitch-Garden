using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A.產生攻擊者
//B.讓生成出的攻擊者可自動歸類成自己生成池的子物件
//C.能亂數生成攻擊者
//D.停止生成攻擊者迴圈的方法

public class AttackerSpawner : MonoBehaviour
{
    public Attacker[] attackerPrefabArray; //A.存放攻擊者的Prefab //C.改成陣列
    public float[] setCountBackward;

    IEnumerator Start()
    {
        for(int i=0; i< attackerPrefabArray.Length; i++)
        {
            if(i == 0)
            {
                yield return new WaitForSeconds(setCountBackward[i]); //等待時間
            }
            else
            {
                yield return new WaitForSeconds(setCountBackward[i] - setCountBackward[i-1]); //等待時間
            }
            Spawn(attackerPrefabArray[i]); //C.執行用亂數產生攻擊者的方法
        }
    }

    //C.產生攻擊者的方法
    private void Spawn (Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
