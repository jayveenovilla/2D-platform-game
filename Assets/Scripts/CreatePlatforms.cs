using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatforms : MonoBehaviour
{
    public GameObject Platform;
    public Transform createPlatform;  //createPlatformHere object is child of main camera so creates new platforms when it is behind that point
    public float distanceFromPlatform;

    private float platformWidth;

    public float distanceFromPlatformMin;
    public float distanceFromPlatformMax;


    // Start is called before the first frame update
    void Start()
    {
        platformWidth = Platform.GetComponent<BoxCollider2D>().size.x;  //width of platform is the width of the Box Collider
    }

    // Update is called once per frame
    void Update()
    {
     if(transform.position.x < createPlatform.position.x)  //generates new platform if current position is less than the creat platform position
        {
            distanceFromPlatform = Random.Range(distanceFromPlatformMin, distanceFromPlatformMax);  //randomize distance between platforms

            transform.position = new Vector3(transform.position.x + platformWidth + distanceFromPlatform, transform.position.y, transform.position.z);  //position of new platform

            Instantiate(Platform, transform.position, transform.rotation); //creates new platform at new position
        }
    }
}
