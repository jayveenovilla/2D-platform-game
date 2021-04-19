using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusScene : MonoBehaviour
{
    public Text textHighScore;
    public Text activeLongJump;
    public Text activeDoubleJump;

    //public Text nameTextField;

    // Start is called before the first frame update
    void Start()
    {

        //nameTextField.text = GameManagerSingleton.Instance.player.playerName;
        Debug.Log("Player Name:" + GameManagerSingleton.Instance.player.playerName);
        if (PlayerPrefs.HasKey("HighScore") == true)     //check if there is a currently saved high score from a previous game session
        {
            GameManagerSingleton.Instance.player.currentHighScore = PlayerPrefs.GetFloat("HighScore");
        }
        textHighScore.text = "High Score: " + Mathf.Round(GameManagerSingleton.Instance.player.currentHighScore);    //display high score as a rounded number

        //enable bonus based on high score
        if( GameManagerSingleton.Instance.player.currentHighScore > 5000000)    //currently disabled for further testing
        {
            GameManagerSingleton.Instance.player.longJump = true;
            activeLongJump.text = "ACTIVE: High score of 500 reached! \n (Hold jump button down for a longer jump)";
        }

        if (GameManagerSingleton.Instance.player.currentHighScore > 1000)       //enabled at 1000 high score
        {
            GameManagerSingleton.Instance.player.doubleJump = true;
            activeDoubleJump.text = "ACTIVE: High score of 1000 reached! \n (Press jump button a second time for a second jump)";
        }

        if (GameManagerSingleton.Instance.player.currentHighScore > 10000)      //not in game yet
        {
            GameManagerSingleton.Instance.player.trapMaster = true;
        }

        if (GameManagerSingleton.Instance.player.currentHighScore > 20000)      //not in game yet
        {
            GameManagerSingleton.Instance.player.beastMaster = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
