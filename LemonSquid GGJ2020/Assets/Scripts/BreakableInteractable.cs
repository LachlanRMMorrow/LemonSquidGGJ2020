using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableInteractable : InteractableBase
{

    public InteractableManager.RepairRequired[] neededItems;

    


    public override bool CanInteract()
    {
        if (InteractableManager.Instance.hasBrokenObject)
        {
            if (InteractableManager.Instance.brokenObject == this)
            {
            return true;
            }
            return false;

        }
        return true;
    }

    public override void Interact()
    {
        if (!InteractableManager.Instance.hasBrokenObject)
        {
            UIManager.Instance.DisplayCurrentObjective(true);
            InteractableManager.Instance.SetBrokenObject(this);
            return;
        }
    }


    public void Break()
    {
        Debug.Log("Break");

      // for (int i = 0; i < transform.childCount; ++i)
      // {
      //     transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
      //     transform.GetChild(i).GetComponent<Rigidbody>().AddForceAtPosition((transform.position - transform.GetChild(0).position) * Random.Range(10, 200), transform.position - new Vector3(0,1,0)) ;
      //     transform.GetChild(i).GetComponent<BoxCollider>().enabled = true;
      // }
        


    }
}
