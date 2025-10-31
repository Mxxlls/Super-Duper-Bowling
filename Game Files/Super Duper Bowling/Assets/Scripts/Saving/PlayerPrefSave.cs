using UnityEngine;

public class PlayerPrefSave : MonoBehaviour
{
    public float bestTime;
    private string bestTimeString;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestTime = 10f;

        int idx = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        if (idx >= 1 && idx <= 6)
        {
            string[] words = { "one", "two", "three", "four", "five", "six" };
            bestTimeString += words[idx - 1];
            Debug.Log(bestTimeString);
        }
        bestTime = PlayerPrefs.GetFloat(bestTimeString);
        Debug.Log(bestTime.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save(float _bestTime)
    {
        // Save a player's score
        PlayerPrefs.SetFloat(bestTimeString, _bestTime);
    }

    [ContextMenu("Reset")]
    public void Reset()
    {
        PlayerPrefs.SetFloat(bestTimeString, 10f);
        bestTime = PlayerPrefs.GetFloat(bestTimeString);
    }
}
