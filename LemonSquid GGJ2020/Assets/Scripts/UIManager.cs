using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBase<UIManager>
{
    [SerializeField] Image currentCrosshair;
    [SerializeField] Sprite lookingAtInteractableCrosshair;
    [SerializeField] Sprite defaultCrosshair;

    // Start is called before the first frame update
    void Start()
    {
        currentCrosshair = GameObject.Find("Crosshair").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleCrosshair(bool amILookingAtObject) 
    {
        if (amILookingAtObject == true)
        {
            currentCrosshair.sprite = lookingAtInteractableCrosshair;
        }
        else 
        {
            currentCrosshair.sprite = defaultCrosshair;
        }
    }
}
