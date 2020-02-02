using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairInteractable : InteractableBase
{

    [SerializeField] private int m_ID;
    public int ID { get { return m_ID; } }


    [SerializeField] private string m_itemName;
    public string itemName { get { return m_itemName; } }
    Rigidbody rb;
    Collider collider;

    public GameObject sparkle;
    protected override void Setup()
    {
        base.Setup();
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();


        if (itemName == "")
            m_itemName = gameObject.name;
    }

    public override bool CanInteract()
    {
        return true;
    }

    public override void Interact()
    {
    }

    public void Grab()
    {
        rb.isKinematic = true;
        collider.enabled = false;
        sparkle.SetActive(false);
    }

    public void Drop()
    {
        rb.isKinematic = false;
        collider.enabled = true;

        rb.AddForce(transform.parent.parent.forward * 200);
        transform.parent = null;
        sparkle.SetActive(true);
    }

}
