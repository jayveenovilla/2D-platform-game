using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatforms : MonoBehaviour
{
    public GameObject Platform;
    public GameObject tmpPlatform;
    public Transform createPlatform;  //createPlatformHere object is child of main camera so creates new platforms when it is behind that point
    public float distanceFromPlatform;

    private float platformWidth;
    private float[] platformWidths;

    public float distanceFromPlatformMin;
    public float distanceFromPlatformMax;

    //public GameObject[] arrPlatform;
    private int selectPlatform;


    public PoolObjects[] arrObjectPool;

    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = Platform.GetComponent<BoxCollider2D>().size.x;  //width of platform is the width of the Box Collider
        platformWidths = new float[arrObjectPool.Length]; //create new platformWidth array as same size of arrPlatform

        for(int i = 0; i < arrObjectPool.Length; i++)
        {
            platformWidths[i] = arrObjectPool[i].poolObject.GetComponent<BoxCollider2D>().size.x;    //width of platform is the width of the Box Collider of the object pool
        }
    }

    // Update is called once per frame
    void Update()
    {
     if(transform.position.x < createPlatform.position.x)  //generates new platform if current position is less than the creat platform position
        {
            distanceFromPlatform = Random.Range(distanceFromPlatformMin, distanceFromPlatformMax);  //randomize distance between platforms

            selectPlatform = Random.Range(0, arrObjectPool.Length);   //select platform randomly

            transform.position = new Vector3(transform.position.x + (platformWidths[selectPlatform]/2) + distanceFromPlatform, transform.position.y, transform.position.z);  //position of new platform

            

            //Instantiate(/*Platform*/arrPlatform[selectPlatform], transform.position, transform.rotation); //creates new platform at new position based on randomly selected platform
            GameObject tmpPlatform = arrObjectPool[selectPlatform].GetPoolObjectsList();  //creates new platform at new position from object pool list

            tmpPlatform.transform.position = transform.position;  //set position of the new platform to calculated position of new platform
            tmpPlatform.transform.rotation = transform.rotation;
            tmpPlatform.SetActive(true);    //plaform default is inactive, activate new platform
            

            transform.position = new Vector3(transform.position.x + (platformWidths[selectPlatform] / 2), transform.position.y, transform.position.z);  //position of new platform

        }
    }
}
