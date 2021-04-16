using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusScene : MonoBehaviour
{
    public Text textHighScore;
    public Text activeLongJump;
    public Text activeDoubleJump;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore") == true)     //check if there is a currently saved high score from a previous game session
        {
            GameManagerSingleton.Instance.player.currentHighScore = PlayerPrefs.GetFloat("HighScore");
        }
        textHighScore.text = "High Score: " + Mathf.Round(GameManagerSingleton.Instance.player.currentHighScore);    //display high score as a rounded number

        //enable bonus based on high score
        if( GameManagerSingleton.Instance.player.currentHighScore > 500)
        {
            GameManagerSingleton.Instance.player.longJump = true;
            activeLongJump.text = "ACTIVE: High score of 500 reached! \n (Hold jump button down for a longer jump)";
        }

        if (GameManagerSingleton.Instance.player.currentHighScore > 2500)
        {
            GameManagerSingleton.Instance.player.doubleJump = true;
            activeDoubleJump.text = "ACTIVE: High score of 2500 reached! \n (Press jump button a second time for a second jump)";
        }

        if (GameManagerSingleton.Instance.player.currentHighScore > 10000)
        {
            GameManagerSingleton.Instance.player.trapMaster = true;
        }

        if (GameManagerSingleton.Instance.player.currentHighScore > 20000)
        {
            GameManagerSingleton.Instance.player.beastMaster = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
