using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetHighScore : MonoBehaviour
{
    public Text textHighScore;
    //public Text bonusDoubleJump;

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");     //deletes high score only
        GameManagerSingleton.Instance.player.currentHighScore = 0;      //singleton score reset to 0
        GameManagerSingleton.Instance.player.doubleJump = false;

        textHighScore.text = "High Score: " + Mathf.Round(GameManagerSingleton.Instance.player.currentHighScore);   //display new high score from saved singleton
        //bonusDoubleJump.text = "INACTIVE: need High Score of 1000 \n (Press jump a second time for a second jump)";
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
