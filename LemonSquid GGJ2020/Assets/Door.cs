using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableBase
{

    bool open = true;
   Quaternion originalRotation;
   Quaternion openRotation;

    protected override void Setup()
    {
        base.Setup();
        open = true;
        originalRotation = transform.rotation;
        openRotation = Quaternion.Euler(originalRotation.eulerAngles + new Vector3(0, 90, 0));
    }

    public override void Interact()
    {
        open = !open;
    }

    private void Update()
    {


        if (open)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, 0.1f);
        }
        else
        {

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(originalRotation.eulerAngles + new Vector3(0, 90, 0)), 0.1f);
        }
    }
}
