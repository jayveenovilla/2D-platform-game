using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    public Text deathMessage;

    // Start is called before the first frame update
    void Start()
    {
        deathMessage.text = GameManagerSingleton.Instance.player.playerName + " DIED!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
