using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawnerController : MonoBehaviour
{
    public List<GameObject> spawnerList;
    public float firstStateTime = 0.3f;
    public float SecondStateTime = 0.6f;
    private bool triggerSecondState = false;

    void Start()
    {
        foreach (GameObject spawner in spawnerList)
        {
            spawner.SetActive(false);
        }
        ActiveState();

        /*
        while (i <= 0)
        {
            ActiveStateByTime(firstStateTime);
            ActiveStateByTime(SecondStateTime);
            i++;
        }
        */
        
    }

    void Update()
    {
        //if (triggerSecondState) { return; }
        //ActiveStateByTime(firstStateTime);
    }

    private void ActiveState()
    {
        int i = Random.Range(0, spawnerList.Count);
        spawnerList[i].SetActive(true);
        //spawnerList.RemoveAt(i);
    }

    private void ActiveStateByTime(float time)
    {
        if (Time.timeSinceLevelLoad >= FindObjectOfType<GameTimer>().levelTime * time)
        {
            ActiveState();
            ActiveState();
            triggerSecondState = true;
        }
    }
}
