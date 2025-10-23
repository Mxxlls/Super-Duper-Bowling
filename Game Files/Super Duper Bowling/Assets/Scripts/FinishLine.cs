using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject winVarObj = GameObject.Find("Win Var");
            Winscript winScript = winVarObj.GetComponent<Winscript>();
            if (winScript != null)
            {
                winScript.win();
                winScript.gameWon = true;
            }
        }
    }
}
