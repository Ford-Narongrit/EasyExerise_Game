using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SquatController : MonoBehaviour
{
    // charge
    [Header("Charger")]
    public GaugeBar chargerBar;
    private float currentCharge = 0;
    public float maxCharge = 2;

    // counter
    [Header("Counter")]
    public TMP_Text counterText;
    private int count = 0;

    // gauge bar
    [Header("GaugeBar")]
    public CounterBar counterBar;
    public int maxCombo;
    private int currentCombo;

    //Timer
    [Header("Timer")]
    public TMP_Text timerText;
    public float maxTimer_seconds = 120f;
    private float currentTimer;

    private void Start()
    {
        chargerBar.SetStartValue(maxCharge);
        counterBar.SetStartCounterValue(maxCombo);
        currentTimer = maxTimer_seconds;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Charge();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Release();
        }

        CountDownTimer();
    }

    private void Charge()
    {
        if (currentCharge <= maxCharge)
        {
            currentCharge += Time.deltaTime;
            chargerBar.SetValue(currentCharge);
        }
    }

    private void Release()
    {
        if (currentCharge >= maxCharge)
        {
            currentCombo += 1;
            counterBar.SetCounterValue(currentCombo);
        }
        else
        {
            currentCombo = 0;
            counterBar.ClearCounter();
        }

        Count();
        currentCharge = 0;
        chargerBar.SetValue(currentCharge);
    }

    private void Count()
    {
        count += 1;
        counterText.text = count + "";
    }

    private void CountDownTimer()
    {
        if (currentTimer > 0 )
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
