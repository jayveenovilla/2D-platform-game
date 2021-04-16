//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//manages persistent character abilities and game state
[SerializeField]
public class GameManagerSingleton : MonoBehaviour
{
    public class Player
    {
        //bonus enabled after high score goal attained
        public float currentHighScore;      //current high score
        bool longJump;      //hold jump button for longer jump
        bool doubleJump;    //double tap jump button for 2nd jump
        bool beastMaster;   //immune to enemy creature damage
        bool invincible;    //immune to platform trap damage


    }



    public static GameManagerSingleton Instance { get; private set; }

    public Player player;

    private void Awake()
    {
        if (Instance != null && Instance !=this)
        {
            Destroy(gameObject);
            

        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            player = new Player();
            
        }
    }
}
