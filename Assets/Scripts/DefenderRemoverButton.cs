using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 配合DefenderRemover
 */

public class DefenderRemoverButton : MonoBehaviour
{
    private bool isRemoverOn;
    public GameObject defenderRemoveCursor;
    private BattleSceneController battleSceneController;

    void Start()
    {
        battleSceneController = FindObjectOfType<BattleSceneController>();
        defenderRemoveCursor.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        isRemoverOn = false;
    }

    void Update()
    {
        GiveMousePosToCursor();
    }

    public void RemoverSwitch()
    {
        if (!isRemoverOn)
        {
            isRemoverOn = true;
            defenderRemoveCursor.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            FindObjectOfType<DefenderSpawner>().SetDefenderNull();
        }
        else
        {
            isRemoverOn = false;
            defenderRemoveCursor.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        FindObjectOfType<BattleSceneController>().gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    public void SetIsRemoverOnFalse()
    {
        isRemoverOn = false;
        defenderRemoveCursor.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void SetIsRemoverOnTrue()
    {
        isRemoverOn = true;
        defenderRemoveCursor.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        FindObjectOfType<DefenderSpawner>().SetDefenderNull();
    }

    public bool GetIsRemoveOn()
    {
        return isRemoverOn;
    }

    public void GiveMousePosToCursor()
    {
        defenderRemoveCursor.transform.GetChild(0).gameObject.transform.position =
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }
}
