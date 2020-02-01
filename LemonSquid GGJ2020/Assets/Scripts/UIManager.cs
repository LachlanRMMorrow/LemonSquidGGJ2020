using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBase<UIManager>
{
    [SerializeField] bool timer1Over;
    [SerializeField] bool timerStarted;

    [SerializeField] float countdownTimer = 1f;
    [SerializeField] Image currentCrosshair;
    [SerializeField] Sprite lookingAtInteractableCrosshair;
    [SerializeField] Sprite defaultCrosshair;
    [SerializeField] GameObject currentObjectiveText;
    [SerializeField] GameObject surviveText;

    public Animator transitionAnimation;

    // Start is called before the first frame update
    void Start()
    {
        transitionAnimation.SetTrigger("Start");

        timer1Over = false;
        timerStarted = false;
        currentCrosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        currentObjectiveText = GameObject.Find("Text Current Objective");
        surviveText = GameObject.Find("Text Survive");
        if (surviveText.activeInHierarchy == true) 
        {
            surviveText.SetActive(false);
        }
        if (currentObjectiveText.activeInHierarchy == true)
        {
            currentObjectiveText.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted == true && timer1Over != true)
        {
            Timer();
        }
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

    public void DisplayCurrentObjective(bool onOrOff) 
    {
        currentObjectiveText.SetActive(onOrOff);
        if (onOrOff && timerStarted == false)
        {
            timerStarted = true;
        }
        if (onOrOff == false) 
        {
            surviveText.SetActive(onOrOff);
        }
    }
    private void Timer()
    {
        countdownTimer -= Time.deltaTime;
        if (countdownTimer <= 0)
        {
            surviveText.SetActive(true);
            timer1Over = true;
            timerStarted = false;
        }
    }
}
