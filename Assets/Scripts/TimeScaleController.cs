using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleController : MonoBehaviour
{
    public void PauseGameTime()
    {
        Time.timeScale = 0;
    }

    public void ResumeGameTime()
    {
        Time.timeScale = 1;
    }
}
