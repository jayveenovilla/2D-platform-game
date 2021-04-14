using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text textScore;
    public Text textHighScore;

    public float cntScore;
    public float cntHighScore;

    public float scorePerSecond;

    public bool isScoreIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        //high score located windows 10 registry: HKEY_CURRENT_USER\SOFTWARE\Unity\UnityEditor\DefaultCompany
        if (PlayerPrefs.HasKey("HighScore") == true)     //check if there is a currently saved high score from a previous game session
        {
            cntHighScore = PlayerPrefs.GetFloat("HighScore");
        }
        isScoreIncreasing = true;   //default setting of bool score increasing to true
}

    // Update is called once per frame
    void Update()
    {
        if (isScoreIncreasing)      //bool if score is increasing
        {
            cntScore += scorePerSecond + Time.deltaTime;    //increase score per second
        }


        if(cntScore > cntHighScore)
        {
            cntHighScore = cntScore;        //set high score if current score higher than previous high score
            PlayerPrefs.SetFloat("HighScore", cntHighScore);        //saves high score between game sessions
        }

        textScore.text = "Score: " + Mathf.Round(cntScore);     //display score as a rounded number
        textHighScore.text = "High Score: " + Mathf.Round(cntHighScore);    //display high score as a rounded number
    }
}
