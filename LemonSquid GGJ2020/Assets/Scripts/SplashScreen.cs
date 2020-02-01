using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashScreen : MonoBehaviour
{
    [SerializeField] private float m_delay;
    [SerializeField] private string m_loadScene;

    private void Start()
    {
        StartCoroutine(Delay());
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(m_delay);

        SceneManager.LoadSceneAsync(m_loadScene);
    }

}
