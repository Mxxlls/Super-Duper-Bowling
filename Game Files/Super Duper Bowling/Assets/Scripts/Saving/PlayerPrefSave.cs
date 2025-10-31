using UnityEngine;

public class PlayerPrefSave : MonoBehaviour
{
    public float bestTime;
    private string bestTimeString;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int idx = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        if (idx >= 1 && idx <= 6)
        {
            string[] words = { "one", "two", "three", "four", "five", "six" };
            bestTimeString += words[idx - 1];
            Debug.Log(bestTimeString);
        }
        bestTime = PlayerPrefs.GetFloat(bestTimeString);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save()
    {
        // Save a player's score
        PlayerPrefs.SetFloat(bestTimeString, bestTime);
        PlayerPrefs.GetString("Pokemon");
    }
}
