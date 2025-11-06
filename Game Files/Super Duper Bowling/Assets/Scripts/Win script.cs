using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Winscript : MonoBehaviour
{
    // winUI will be the win screen and it should display "Strike!" as well as a
    // menu and retry button, also showing your time
    public int pins;
    private float time = 0;
    private bool timerActive = false;
    public int levelPins = 0;
    public GameObject winUI; // Added declaration for winUI
    public GameObject timeText; // Renamed from 'Time' to 'timeText'
    public GameObject pinScore;
    public GameObject oldPinScore;
    public static bool GameIsPaused = false;
    public GameObject timeCounter;

    public GameObject winCam; // win cam reference to activate
    public GameObject playerCam; // playercam reference to deactivate

    public GameObject player;
    public GameObject BestTime;
    public bool gameWon = false;
    public Animator winUiAnim;
    void Start()
    {
        pins = 0;
        timerActive = true;
        GameIsPaused = false;
        winCam.GetComponent<Camera>().enabled = false;
    }
    public void win()
    {
        playerCam.SetActive(false); //disables old camera
        winCam.GetComponent<Camera>().enabled = true; //switches camera
        GameIsPaused = true;
        Debug.Log("Strike!"); // Temporary win log
        //Time.timeScale = 0; // Slow down all gameplay (not framerate)
        winUI.SetActive(true); //sets win menu active.
        oldPinScore.SetActive(false);
        timeCounter.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponentInChildren<MeshRenderer>().enabled = true;
        player.transform.localScale = new Vector3(1f, 1f, 1f);
        // timer
        TimerController.instance.EndTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
            time = time + Time.deltaTime;

        //display score
        pinScore.GetComponent<TextMeshProUGUI>().text = "Pins Hit: " + pins + "/" + levelPins;
        oldPinScore.GetComponent<TextMeshProUGUI>().text = "Pins Hit: " + pins + "/" + levelPins;
    }
}
