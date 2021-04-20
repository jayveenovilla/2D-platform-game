using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text textScore;
    public Text textHighScore;
    public Text textPlayerName;
    public Text textBonus;

    public float cntScore;

    public float scorePerSecond;

    public bool isScoreIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManagerSingleton.Instance.player.doubleJump)
        {
            textBonus.text = "Bonus: Double Jump";
        }
        //high score located windows 10 registry: HKEY_CURRENT_USER\SOFTWARE\Unity\UnityEditor\JNovilla
        GameManagerSingleton.Instance.player.currentScore = 0;
        cntScore = 0;
        isScoreIncreasing = true;   //default setting of bool score increasing to true
        textHighScore.text = "High Score: " + Mathf.Round(GameManagerSingleton.Instance.player.currentHighScore);    //display high score as a rounded number
        textPlayerName.text = GameManagerSingleton.Instance.player.playerName;      //display Player Name under high score
    }

    // Update is called once per frame
    void Update()
    {
        if (isScoreIncreasing)      //bool if score is increasing
        {
            cntScore += scorePerSecond + Time.deltaTime;    //increase score per second
        }


        if(cntScore > GameManagerSingleton.Instance.player.currentHighScore)
        {
            GameManagerSingleton.Instance.player.currentHighScore = cntScore;        //set high score if current score higher than previous high score
            PlayerPrefs.SetFloat("HighScore", GameManagerSingleton.Instance.player.currentHighScore);        //saves high score between game sessions
        }

        textScore.text = "Score: " + Mathf.Round(cntScore);     //display score as a rounded number
        textHighScore.text = "High Score: " + Mathf.Round(GameManagerSingleton.Instance.player.currentHighScore);    //display high score as a rounded number
        textPlayerName.text = GameManagerSingleton.Instance.player.playerName;      //display Player Name under high score
        if (GameManagerSingleton.Instance.player.doubleJump)
        {
            textBonus.text = "Bonus: Double Jump";
        }
    }

    public void addToCurrentScore(int value)    //add to current score bonuses from items, etc.
    {
        cntScore = cntScore + value;
        GameManagerSingleton.Instance.player.currentScore = cntScore;
    }
}
