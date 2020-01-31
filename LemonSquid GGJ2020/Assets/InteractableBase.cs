using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // TEMP - Used to correct for weird scale on placeholder objects
        transform.position += Vector3.up * transform.localScale.y/2;    
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



    public virtual void Interact()
    {
        Debug.Log("Break");    
    }
}
