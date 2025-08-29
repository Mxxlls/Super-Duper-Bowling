using UnityEngine;

public class Winscript : MonoBehaviour
{
    // winUI will be the win screen and it should display "Strike!" as well as a
    // menu and retry button, also showing your time
    public int pins;
    private float time = 0;
    private bool timerActive = false;
    public int levelPins;
    void Start()
    {
        pins = 0;
        // Optionally assign winUI if not set in Inspector:
        winUI = GameObject.Find("winUI");
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
            time = time + Time.deltaTime;
        if (pins >= levelPins)
        {
            Debug.Log("Strike!"); // Temporary win log
            Time.timeScale = 0; // Slow down all gameplay (not framerate)
            if (winUI != null)
            {
                winUI.SetActive(true); //sets win menu active.
                // When implemented, the if statement can be deleted.
            }
        }
    }
}
