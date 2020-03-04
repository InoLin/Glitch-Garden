using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncManager : MonoBehaviour
{
    AsyncOperation async;
    public Slider loadingSlider;

    void Start()
    {
        async = SceneManager.LoadSceneAsync("Level 01");
        async.allowSceneActivation = false;
    }

    void Update()
    {
        loadingSlider.value = async.progress;

        if (async.progress >= 0.9f)
        {
            async.allowSceneActivation = true;
        }
    }
}
