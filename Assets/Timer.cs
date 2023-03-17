 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine; 
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public GameObject buttan;
    Image timerBar;
    public GameObject pause;
    public float maxTime = 150f;
    bool notStarted = false;
    public float timeLeft;


    public void TapStart()
    {
        Time.timeScale = 1;
        buttan.SetActive(false);
        notStarted = true;
    }


    void Start() {

        Time.timeScale = 0;
        timerBar = GetComponent<Image>();

        timeLeft = maxTime;

    }


    public void MinusTime()
    {
        if (maxTime > 5)
        {
            maxTime--;
            timeLeft = maxTime;
        }
        else if (maxTime < 6)
        {
            timeLeft = maxTime;
        }
    }


    void Update() {

        if (notStarted == true) {
            if (timeLeft > 0)
            {

                timeLeft -= 0.01f;

                timerBar.fillAmount = timeLeft / maxTime;

            }
            else
            {

                Time.timeScale = 0;
                pause.SetActive(true);
            }
        }
    }
}

  
