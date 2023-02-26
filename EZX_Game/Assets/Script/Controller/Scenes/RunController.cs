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

    //Item
    [Header("Item")]
    public GameObject[] items;
    public GameObject[] lanes;
    private float delaySpawnTime = 5f;
    private float nextSpawnTime = 0f;

    //player
    [Header("player")]
    public PlayerRunController player;

    private void Start()
    {
        currentTimer = maxTimer_seconds;
        nextSpawnTime = maxTimer_seconds;
    }

    private void Update()
    {
        CountDownTimer();
        spawnItem();
        udpateScore();
    }

    private void udpateScore()
    {
        count = (int)player.point;
        counterText.text = count + "";
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

    private void spawnItem()
    {
        if (currentTimer <= nextSpawnTime)
        {
            GameObject newItem = Instantiate(randomItems(), randomLanes().transform.position, Quaternion.identity);
            nextSpawnTime = currentTimer - delaySpawnTime;
        }
    }

    private GameObject randomItems()
    {
        float value = Random.value;
        if (value <= 0.7)
        {
            return items[0];
        }
        else if (value > 0.7)
        {
            return items[1];
        }
        return null;
    }

    private GameObject randomLanes()
    {
        float value = Random.value;
        if (value < 0.25)
        {
            return lanes[0];
        }
        else if (value < 0.50)
        {
            return lanes[1];
        }
        else if (value < 0.75)
        {
            return lanes[2];
        }
        else if (value < 1)
        {
            return lanes[3];
        }
        return null;
    }
}
