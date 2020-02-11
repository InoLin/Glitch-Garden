using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text time;

    void Start()
    {

    }

    void Update()
    {
        time.text = "經過時間: " + Time.timeSinceLevelLoad.ToString("0");

    }
}
