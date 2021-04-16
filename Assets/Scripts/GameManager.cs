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

    //public SceneManagerScript mySceneManager;

    public RestartMenu myRestartMenu;

    // Start is called before the first frame update
    void Start()
    {
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
        //StartCoroutine("RestartCoroutine");
        Player.gameObject.SetActive(false);     //inactivate Player
        myScoreManager.isScoreIncreasing = false;
        myRestartMenu.gameObject.SetActive(true);
    }

    /*public IEnumerator RestartCoroutine()
    {
        
        myScoreManager.isScoreIncreasing = false;   //stops increasing score upon player death
        Player.gameObject.SetActive(false);     //inactivate Player
        yield return new WaitForSeconds(0.5f);  //delay for .5 seconds
        arrPlatform = FindObjectsOfType<DestroyPlatforms>();    //find all the object platforms running the script DestroyPlatforms
        for(int i =0; i < arrPlatform.Length; i++)
        {
            arrPlatform[i].gameObject.SetActive(false);     //set all the object platforms found running script DestroyPlatforms to inactive
        }
        createPlatform.position = startPlatform;    //set position of platform to start of game
        Player.transform.position = startPlayer;    //set position of player to start of game
        Player.gameObject.SetActive(true);      //activate Player
        myScoreManager.cntScore = 0;    //reset current score to 0
        myScoreManager.isScoreIncreasing = true;    //allows score to increase upon reset
        
}*/
    // Update is called once per frame
    void Update()
    {

    }
}
