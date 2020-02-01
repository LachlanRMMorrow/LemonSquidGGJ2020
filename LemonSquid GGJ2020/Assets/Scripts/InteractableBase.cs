using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableBase : MonoBehaviour
{

    [SerializeField] protected AudioSource source;
    protected virtual void Setup()
    {
        source = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }


    public virtual bool CanInteract()
    {
       return true;
    }

    public virtual void Interact()
    {
        if (source != null)
        {
            source.PlayOneShot(source.clip);
        }
    }


}
