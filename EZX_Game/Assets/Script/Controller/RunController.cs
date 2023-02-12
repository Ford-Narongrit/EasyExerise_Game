using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RunController : MonoBehaviour
{
    // counter
    [Header("Counter")]
    public TMP_Text counterText;
    private int count = 0;

    //Timer
    [Header("Timer")]
    public TMP_Text timerText;
    public float maxTimer_seconds = 120f;
    private float currentTimer;

    private void Start()
    {
        currentTimer = maxTimer_seconds;
    }

    private void Update()
    {
        CountDownTimer();
    }

    private void CountDownTimer()
    {
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }
        else
        {
            currentTimer = 0;
        }

        float minutes = Mathf.FloorToInt(currentTimer / 60);
        float seconds = Mathf.FloorToInt(currentTimer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
