using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A.產生攻擊者
//B.讓生成出的攻擊者可自動歸類成自己生成池的子物件
//C.能亂數生成攻擊者
//D.停止生成攻擊者迴圈的方法

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool SpawnRiquire = true; //A.
    [SerializeField] float minSpawnDelay = 3f; //A.
    [SerializeField] float maxSpawnDelay = 7f; //A.
    public Attacker[] attackerPrefabArray; //A.存放攻擊者的Prefab //C.改成陣列

    IEnumerator Start() 
    {

        while (SpawnRiquire) //A.當SpawnRiquire為true
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay * (1 - Time.timeSinceLevelLoad / ( FindObjectOfType<GameTimer>().levelTime * 2 )),
                                                        maxSpawnDelay) * (1 - Time.timeSinceLevelLoad / ( FindObjectOfType<GameTimer>().levelTime * 2 ))); //等待時間
            SpawnAttacker(); //C.執行用亂數產生攻擊者的方法
        }
    }


    //C.用亂數指定要產生哪個攻擊者的方法
    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    //C.產生攻擊者的方法
    private void Spawn (Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    //D.
    public void StopSpawning()
    {
        SpawnRiquire = false;
    }
}
