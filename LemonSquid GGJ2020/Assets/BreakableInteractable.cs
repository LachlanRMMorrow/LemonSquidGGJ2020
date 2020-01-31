using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableInteractable : InteractableBase
{

    public override bool CanInteract()
    {
        return !InteractableManager.Instance.hasBrokenObject;
    }

    public override void Interact()
    {
        if (!InteractableManager.Instance.hasBrokenObject)
        {
            InteractableManager.Instance.SetBrokenObject(this);
            return;
        }
    }


    private void Break()
    {
        Debug.Log("Break");

    }
}
