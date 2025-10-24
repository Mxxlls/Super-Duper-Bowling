using System;
using System.Collections;
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
    public GameObject pinScore;
    public GameObject BestTime;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        timeCounter.text = "Time: 00:00.000";
        timerGoing = false;

        // Initialize BestTime UI from SaveManager if available
        if (SaveManager.Instance != null)
        {
            BestTime.GetComponent<TextMeshProUGUI>().text = FormatBestTimeUI(SaveManager.Instance.bestTime);
        }
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

        // If we have a SaveManager, compare and save best time
        if (SaveManager.Instance != null)
        {
            // If no best time saved yet, bestTime will be PositiveInfinity
            if (elapsedTime < SaveManager.Instance.bestTime)
            {
                SaveManager.Instance.bestTime = elapsedTime;
                SaveManager.Instance.SaveGame();
            }

            BestTime.GetComponent<TextMeshProUGUI>().text = FormatBestTimeUI(SaveManager.Instance.bestTime);
        }
        else
        {
            BestTime.GetComponent<TextMeshProUGUI>().text = "Best: --:--.---";
        }
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

    private string FormatBestTimeUI(float seconds)
    {
        if (float.IsPositiveInfinity(seconds) || seconds <= 0f)
            return "Best: --:--.---";

        TimeSpan ts = TimeSpan.FromSeconds(seconds);
        return "Best: " + ts.ToString("mm':'ss'.'fff");
    }
}