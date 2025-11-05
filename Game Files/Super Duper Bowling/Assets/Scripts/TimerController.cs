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
    public PlayerPrefSave save;
    public float bestTime;
    private string bestTimeString;
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
            TryGetComponent(out PlayerPrefSave save);
            BestTime.GetComponent<TextMeshProUGUI>().text = FormatBestTimeUI(save.bestTime);
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
        Debug.Log("We hit 1");
        TryGetComponent(out PlayerPrefSave save);
        // If no best time saved yet, bestTime will be PositiveInfinity
        if (elapsedTime < save.bestTime || save.bestTime == 0f)
        {
            Debug.Log("Save is called");
            bestTime = elapsedTime;
            save.Save(bestTime);
            BestTime.GetComponent<TextMeshProUGUI>().text = FormatBestTimeUI(bestTime);
        }
        else
        {
            int idx = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            if (idx >= 1 && idx <= 6)
            {
                string[] words = { "one", "two", "three", "four", "five", "six" };
                bestTimeString += words[idx - 1];
                Debug.Log(bestTimeString);
            }

            bestTime = PlayerPrefs.GetFloat(bestTimeString);
            PlayerPrefs.Save();
            BestTime.GetComponent<TextMeshProUGUI>().text = FormatBestTimeUI(bestTime);
        }
        // // If we have a SaveManager, compare and save best time
        // if (bestTime != null)
        // {


        //     BestTime.GetComponent<TextMeshProUGUI>().text = FormatBestTimeUI(bestTime);
        // }
        // else
        // {
        //     BestTime.GetComponent<TextMeshProUGUI>().text = "Best: --:--.---";
        // }
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