using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : Singleton<Timer>
{
    float currentTime = 0f;
    [SerializeField] private Text timerText = null;
    //public static bool timerFinished = false;
    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        DisplayTime(currentTime);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); //converts time to minutes
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // converts time 

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public string GetCurrentTime() 
    {
        return timerText.text;
    }
}
