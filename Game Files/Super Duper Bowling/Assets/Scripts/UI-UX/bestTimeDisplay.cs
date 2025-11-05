using UnityEngine;
using UnityEngine.UI;

public class bestTimeDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Text>().text = "Best Time: " + PlayerPrefs.GetFloat("bestTime").ToString("F3") + "s";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
