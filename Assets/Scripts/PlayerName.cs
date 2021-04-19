using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public string myName;
    public GameObject nameInputField;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayerName()
    {
        myName = nameInputField.GetComponent<Text>().text;      //get text component and set to string variable
        GameManagerSingleton.Instance.player.playerName = myName;       //save string to singleton
        if (GameManagerSingleton.Instance.player.playerName == "")      //if field is left blank and singleton is empty then default player name is "Player"
        {
            GameManagerSingleton.Instance.player.playerName = "Player";
        }
            
    }
}
