using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusScene : MonoBehaviour
{
    public Text textHighScore;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore") == true)     //check if there is a currently saved high score from a previous game session
        {
            GameManagerSingleton.Instance.player.currentHighScore = PlayerPrefs.GetFloat("HighScore");
        }
        textHighScore.text = "High Score: " + Mathf.Round(GameManagerSingleton.Instance.player.currentHighScore);    //display high score as a rounded number
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
