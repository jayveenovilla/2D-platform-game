using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatforms : MonoBehaviour
{
    public GameObject destroyPlatformHere;  

    // Start is called before the first frame update
    void Start()
    {
        destroyPlatformHere = GameObject.Find("DestroyPlatformHere");  //find destroyPlatformHere object
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < destroyPlatformHere.transform.position.x)  //destroyPlatformHere object is child of main camera so destroy new platforms when it is behind the player
        {
            Destroy(gameObject);

            //gameObject.SetActive(false);
        }
    }
}
