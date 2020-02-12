using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A.用動畫event呼叫摧毀特效自己gameobject的方法

public class OnceVFX : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //A.
    private void DestroyItself()
    {
        Destroy(this.gameObject);
    }
}
