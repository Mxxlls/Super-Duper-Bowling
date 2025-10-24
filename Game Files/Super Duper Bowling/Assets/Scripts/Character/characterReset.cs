using UnityEngine;
using UnityEngine.SceneManagement;
public class characterReset : MonoBehaviour
{
    public float resetHeight = -10f;
    public GameObject winScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.y < resetHeight && winScript == false) && Winscript.GameIsPaused == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
