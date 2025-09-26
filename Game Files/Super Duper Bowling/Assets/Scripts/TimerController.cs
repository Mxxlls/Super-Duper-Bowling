using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public TextMeshProUGUI timeCounter;
    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;
    public string timePlayingStr;
    public GameObject timeText;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;
    }
    public void StartTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }
    public void EndTimer()
    {
        timerGoing = false;
        timeText.GetComponent<TextMeshProUGUI>().text = timePlayingStr;
    }
    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'fff");
            timeCounter.text = timePlayingStr;
            yield return null;
        }
    }
}
