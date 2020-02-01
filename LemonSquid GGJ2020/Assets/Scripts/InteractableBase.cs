﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableBase : MonoBehaviour
{
    protected virtual void Setup()
    {
    }


    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {       


        // Debug
        if (Input.GetKeyDown(KeyCode.T))
        {
            Interact();
        }
    }


    public virtual bool CanInteract()
    {
       return true;
    }

    public virtual void Interact()
    {

    }


}
