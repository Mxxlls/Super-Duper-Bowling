using UnityEngine;

public class Winscript : MonoBehaviour
{
    // winUI will be the win screen and it should display "Strike!" as well as a
    // menu and retry button, also showing your time
    public int pins;
    private float time = 0;
    private bool timerActive = false;
    public int levelPins;
    public GameObject winUI; // Added declaration for winUI
    public static bool GameIsPaused = false;

    void Start()
    {
        pins = 0;
        timerActive = true;
    }
    public void win()
    {
        GameIsPaused = true;
        Debug.Log("Strike!"); // Temporary win log
        Time.timeScale = 0; // Slow down all gameplay (not framerate)
        winUI.SetActive(true); //sets win menu active.            
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
            time = time + Time.deltaTime;
        if (pins >= levelPins)
        {
            win();
        }
    }
}
