using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : SingletonBase<ScreenFade>
{

    CanvasGroup image;

  public  bool active;
    float timer = 5;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            image.alpha = Mathf.Lerp(image.alpha, 1, 0.01f);
           timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Application.Quit();
                Debug.Log("Quitting");
            }
        }
    }

    public void Activate()
    {
        active = true;
        image.alpha = 0;
    }
}
