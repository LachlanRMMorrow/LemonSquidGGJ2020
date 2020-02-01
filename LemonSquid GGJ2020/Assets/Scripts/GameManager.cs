using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    public float countdownTimer = 30f;
    private bool timerOver;
    private bool timerStarted;

    // Start is called before the first frame update
    void Start()
    {
        timerOver = false;
        timerStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOver == false && timerStarted == true) 
        {
            Timer();
        }

    }

    private void Timer()
    {
        countdownTimer -= Time.deltaTime;
        if (countdownTimer <= 0) 
        {
            Debug.Log("HOMIE IS HOME");
            timerOver = true;
            Complete(false);
        }
    }

    public void StartTimer() 
    {
        timerStarted = true;
        AudioManager.Instance.PlayerScreech();
    }



    public void Complete(bool success)
    {
        if (success == false) 
        {
            timerOver = true;
        }
        else 
        {
            Debug.Log("KAZOO");
            AudioManager.Instance.PlayKazooForRealzies();
        }
    }
}
