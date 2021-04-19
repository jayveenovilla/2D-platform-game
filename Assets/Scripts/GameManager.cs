using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform createPlatform;
    private Vector3 startPlatform;

    public PlayerController Player;
    private Vector3 startPlayer;

    private DestroyPlatforms[] arrPlatform;

    private ScoreManager myScoreManager;

    public RestartMenu myRestartMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("GameMusicPlayer");     //stop playing music from main menu
        if (go)
        {
            Destroy(go.gameObject);
            Debug.Log("GameMusicPlayer has been destroyed.");
        }
        myRestartMenu.gameObject.SetActive(false);
        Player.gameObject.SetActive(true);      //activate Player
        startPlatform = createPlatform.position;    //default position of platform at start of game
        startPlayer = Player.transform.position;    //default position of player at start of game
        myScoreManager = FindObjectOfType<ScoreManager>();      //find score manager object
        myScoreManager.cntScore = 0;    //reset current score to 0
        myScoreManager.isScoreIncreasing = true;    //allows score to increase upon reset
    }

    public void Restart()   //restart game to be used on Player death
    {
        Player.gameObject.SetActive(false);     //inactivate Player
        myScoreManager.isScoreIncreasing = false;       //turn off score increasing
        myRestartMenu.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
