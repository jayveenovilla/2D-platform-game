using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupItem : MonoBehaviour
{
    public int pointsWorth;

    private ScoreManager myScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        myScoreManager = FindObjectOfType<ScoreManager>();   //find object score manager
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //check if Player collider touches item collider
    {
        if(collision.gameObject.name == "Player")
        {
            AudioClipScript.PlayAudioClip("Picked Coin Echo");  //play coin audio
            myScoreManager.addToCurrentScore(pointsWorth);  //call function add to current score and add the item's value to the score
            gameObject.SetActive(false);    //deactivate item upon touching it
        }
    }
}
