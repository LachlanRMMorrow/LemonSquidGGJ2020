using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBase<UIManager>
{
    [SerializeField] bool timer1Over;
    [SerializeField] bool timer2Over;
    [SerializeField] bool timer3Over;
    [SerializeField] bool timerStarted;

    [SerializeField] float countdownTimer = 1f;
    [SerializeField] float countdownTimerOriginal = 1f;
    [SerializeField] Image currentCrosshair;
    [SerializeField] Sprite lookingAtInteractableCrosshair;
    [SerializeField] Sprite defaultCrosshair;
    [SerializeField] GameObject currentObjectiveText;
    [SerializeField] GameObject surviveText;
    [SerializeField] TMPro.TextMeshProUGUI TextSubCategory;

    public Animator transitionAnimation;

    // Start is called before the first frame update
    void Start()
    {
        countdownTimerOriginal = countdownTimer;
        timer1Over = false;
        timer2Over = false;
        timer3Over = false;
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
            Timer(1);
        }
        if (timerStarted == true && timer2Over != true && timer1Over == true)
        {
            Timer(2);
        }
        if (timerStarted == true && timer3Over != true && timer2Over == true)
        {
            Timer(3);
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
    private void Timer(int timerToRun)
    {
        countdownTimer -= Time.deltaTime;
        if (countdownTimer <= 0 && timerToRun == 1)
        {
            surviveText.SetActive(true);
            timer1Over = true;
            //timerStarted = false;
            countdownTimer = countdownTimerOriginal;
        }
        if (countdownTimer <= 0 && timerToRun == 2)
        {
            transitionAnimation.SetTrigger("Start");
            timer2Over= true;
            //timerStarted = false;
            countdownTimer = countdownTimerOriginal+0.5f;
        }
        if (countdownTimer <= 0 && timerToRun == 3)
        {
            TextSubCategory.enabled = true;
            timer3Over = true;
            timerStarted = false;
        }
    }
}
