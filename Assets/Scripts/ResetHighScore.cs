using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetHighScore : MonoBehaviour
{
    public Text textHighScore;
    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore"); //deletes high score only
        //PlayerPrefs.DeleteAll();      //deletes all player preferences
        GameManagerSingleton.Instance.player.currentHighScore = 0;
        textHighScore.text = "High Score: " + Mathf.Round(GameManagerSingleton.Instance.player.currentHighScore);

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
