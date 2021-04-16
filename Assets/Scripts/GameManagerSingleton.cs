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
        //player saved bonus selections to go here

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
