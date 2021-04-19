using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetHighScore : MonoBehaviour
{
    public Text textHighScore;
    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");     //deletes high score only
        GameManagerSingleton.Instance.player.currentHighScore = 0;      //singleton score reset to 0
        textHighScore.text = "High Score: " + Mathf.Round(GameManagerSingleton.Instance.player.currentHighScore);   //display new high score from saved singleton

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
