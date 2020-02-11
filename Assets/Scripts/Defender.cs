using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A.獎盃用來增加星數的方法，要在Animation增加event來使用此方法
//B.取得星數的方法

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    //A.
    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    //B.
    public int GetStarCost()
    {
        return starCost;
    }
}
