using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableBase
{

    bool open = true;
    Quaternion originalRotation;
    Quaternion openRotation;


    [SerializeField] AudioClip openClip;
    [SerializeField] AudioClip closeClip;

    Transform player;
    bool playerInFront;

    protected override void Setup()
    {
        base.Setup();
        open = true;
        originalRotation = transform.rotation;
        openRotation = Quaternion.Euler(originalRotation.eulerAngles + new Vector3(0, 90, 0));

        player = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().transform;

    }

    public override void Interact()
    {
        open = !open;

        source.PlayOneShot(open ? openClip : closeClip);

        playerInFront = PlayerInFront();
    }

    private void Update()
    {


        if (open)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, 0.1f);
        }
        else
        {
            if (playerInFront)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(originalRotation.eulerAngles + new Vector3(0, 90, 0)), 0.1f);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(originalRotation.eulerAngles + new Vector3(0, -90, 0)), 0.1f);
            }
        }
    }


    public bool PlayerInFront()
    {
        Vector3 heading = player.position - transform.position;

        float dot = Vector3.Dot(heading, -transform.right);

        if (0.5f< dot)
        {
            return true;
        }

        return false;

    }

}
