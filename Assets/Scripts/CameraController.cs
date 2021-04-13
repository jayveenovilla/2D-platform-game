using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController Player;  //player data

    private Vector3 OldPlayerPosition;  
    private float distanceCameraMove;  

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerController>();
        OldPlayerPosition = Player.transform.position;  //player position at start
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceCameraMove = Player.transform.position.x - OldPlayerPosition.x; //camera moves this amount

        transform.position = new Vector3(transform.position.x + distanceCameraMove, transform.position.y, transform.position.z);  //camera moves only on x axis changes of the player

        OldPlayerPosition = Player.transform.position; //updated position of player
    }
}
