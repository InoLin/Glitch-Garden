using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 配合DefenderRemoverButton
 */

public class DefenderRemover : MonoBehaviour
{
    private DefenderRemoverButton defenderRemoverButton;
    public GameObject hitVFX;

    void Start()
    {
        defenderRemoverButton = FindObjectOfType<DefenderRemoverButton>();
    }

    private void OnMouseDown()
    {
        DefenderRemove();
    }

    private void DefenderRemove()
    {
        if (defenderRemoverButton.GetIsRemoveOn())
        {
            defenderRemoverButton.SetIsRemoverOnFalse();
            Instantiate(hitVFX, transform.position, transform.rotation);
            this.gameObject.GetComponent<Defender>().IsDead();
        }
    }
}
