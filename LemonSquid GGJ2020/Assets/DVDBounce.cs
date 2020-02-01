using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDBounce : MonoBehaviour
{
   public Vector3 moveDirection;
    RectTransform rect;
    public float speed;
   public Vector2 bounds;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (rect.position.y > 540)
        {
            Debug.Log("Happened");
          //  moveDirection.y = -0.5f;
        }
    }
}
