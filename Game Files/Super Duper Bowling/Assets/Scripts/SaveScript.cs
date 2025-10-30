using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private string savePath;
    // bestTime in seconds; use PositiveInfinity when no best time saved yet
    public float bestTime = float.PositiveInfinity;

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

    public void SaveGame()
    {
        PlayerSaveData data = new PlayerSaveData { bestTime = bestTime };
        string json = JsonUtility.ToJson(data);
        try
        {
            File.WriteAllText(savePath, json);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save game: " + e.Message);
        }
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            try
            {
                string json = File.ReadAllText(savePath);
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