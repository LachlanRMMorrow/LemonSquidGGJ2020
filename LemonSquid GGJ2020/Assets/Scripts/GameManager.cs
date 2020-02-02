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
    [SerializeField] TMPro.TextMeshProUGUI timerText;


    public GameObject confetti;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "";
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

        float minutes = Mathf.Floor(countdownTimer / 60);
        float seconds = Mathf.Floor(countdownTimer % 60);
        
        timerText.text = minutes + ":" + seconds;
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
            ScreenFade.Instance.Activate();
            //Application.Quit();
            //  Debug.Log("Quitting");
        }
        else
        {
            confetti.SetActive(true);
            Debug.Log("KAZOO");
            AudioManager.Instance.PlayKazooForRealzies();
        }
    }
}
