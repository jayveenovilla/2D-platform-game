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
        public bool longJump;      //hold jump button for longer jump
        public bool doubleJump;    //double tap jump button for 2nd jump
        public bool trapMaster;    //immune to platform trap damage
        public bool beastMaster;   //immune to enemy creature damage



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
