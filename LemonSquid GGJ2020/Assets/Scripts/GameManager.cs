using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonBase<GameManager>
{
    public float countdownTimer = 30f;
    private bool timerOver;
    private bool timerStarted;
    [SerializeField] TMPro.TextMeshProUGUI wastedText;

    // Start is called before the first frame update
    void Start()
    {
        wastedText.enabled = false;
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
        if (!success) 
        {
            timerOver = true;
            wastedText.enabled = true;
            new WaitForSeconds(3);
            Application.Quit();
            Debug.Log("Quitting");
        }
        else 
        {
            Debug.Log("KAZOO");
            AudioManager.Instance.PlayKazooForRealzies();
        }
    }
}
