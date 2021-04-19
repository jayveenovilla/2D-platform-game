using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public string myName;
    public GameObject nameInputField;
    //public GameObject nameText;

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
        myName = nameInputField.GetComponent<Text>().text;
        GameManagerSingleton.Instance.player.playerName = myName;
        if (GameManagerSingleton.Instance.player.playerName == "")
        {
            GameManagerSingleton.Instance.player.playerName = "Player";
        }
            
        //Debug.Log("Function-Player Name:" + GameManagerSingleton.Instance.player.playerName);
        //nameText.GetComponent<Text>().text = "Name: " + GameManagerSingleton.Instance.player.playerName;
    }
}
