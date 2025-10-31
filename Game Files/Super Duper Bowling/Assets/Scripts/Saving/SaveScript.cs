using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private string savePath;
    // bestTime in seconds; use PositiveInfinity when no best time saved yet
    public float bestTime = float.PositiveInfinity;
    public string bestTimeString = "bestTime";
    public float bestTimeOne, bestTimeTwo, bestTimeThree, bestTimeFour, bestTimeFive, bestTimeSix;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        savePath = Path.Combine(Application.persistentDataPath, "playerData.json");
        LoadGame();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log(savePath);
        }
    }
    public void SaveGame()
    {
        int idx = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        string fileName = "playerData";
        if (idx >= 1 && idx <= 6)
        {
            string[] words = { "one", "two", "three", "four", "five", "six" };
            bestTimeString += words[idx - 1];
            Debug.Log(bestTimeString);
        }

        // build path for this save
        string currentSavePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        // update the instance savePath if you want future loads to use this file
        savePath = currentSavePath;

        PlayerSaveData data = new PlayerSaveData(bestTime, bestTimeOne, bestTimeTwo, bestTimeThree, bestTimeFour, bestTimeFive, bestTimeSix);
        // { 
        //     bestTime = bestTime;
        //     bestTimeOne = bestTimeOne;
        //     bestTimeTwo = bestTimeTwo;
        //     bestTimeThree = bestTimeThree;
        //     bestTimeFour = bestTimeFour;
        //     bestTimeFive = bestTimeFive;
        //     bestTimeSix = bestTimeSix;
        // }
        string json = JsonUtility.ToJson(data);
        try
        {
            File.WriteAllText(currentSavePath, json);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save game: " + e.Message);
        }
    }

    public void LoadGame()
    {
        // determine scene-specific file name and path first
        int idx = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        string fileName = "playerData";
        if (idx >= 1 && idx <= 6)
        {
            string[] words = { "one", "two", "three", "four", "five", "six" };
            bestTimeString += "_" + words[idx - 1];
        }

        // build path for this save and update the instance savePath
        string currentSavePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        savePath = currentSavePath;

        if (File.Exists(currentSavePath))
        {
            try
            {
                string json = File.ReadAllText(currentSavePath);
                PlayerSaveData loaded = JsonUtility.FromJson<PlayerSaveData>(json);
                if (loaded != null)
                {
                    bestTime = loaded.bestTime;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("Failed to load save file: " + e.Message);
            }
        }
        else
        {
            // No save file yet; keep bestTime as PositiveInfinity
        }
    }
}