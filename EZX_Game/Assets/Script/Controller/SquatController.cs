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
    public float maxCharge = 3;

    // counter
    [Header("Counter")]
    public TMP_Text counterText;
    private int count = 0;

    // gauge bar
    [Header("GaugeBar")]
    public CounterBar counterBar;
    public int maxCombo;
    private int currentCombo;

    private void Start()
    {
        chargerBar.SetStartValue(maxCharge);
        counterBar.SetStartCounterValue(maxCombo);
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
}
