using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashScreen : MonoBehaviour
{
    [SerializeField] private float m_delay;
    [SerializeField] private bool useDelay;
    [SerializeField] private string m_loadScene;

    private void Start()
    {
        if (useDelay) 
        {
            StartCoroutine(Delay());
        }
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(m_delay);
        LoadNextSceneMyBoi(m_loadScene);
    }
        

    private void LoadNextSceneMyBoi(string loadMe) 
    {
     SceneManager.LoadSceneAsync(loadMe);
    }

    public void TellMeYourName(TMPro.TMP_InputField playerName) 
    {
        if (playerName.text.Length >= 1) 
        {
            PlayerPrefs.SetString("PlayerName", playerName.text);
            Debug.Log("yeetus completus");
        }
    }
}
