using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    public GameObject poolObject;

    public int poolCnt;

    List<GameObject> poolObjectsList;  //list of objects in the pool

    // Start is called before the first frame update
    void Start()
    {
        poolObjectsList = new List<GameObject>();

        for(int i =0; i< poolCnt; i++)
        {
            GameObject tmp = (GameObject)Instantiate(poolObject);  //cast poolObject as gameobject
            tmp.SetActive(false);  //set object as not active as default
            poolObjectsList.Add(tmp);  //add the inactive object to the pool object list
        }
    }

    public GameObject GetPoolObjectsList()
    {
        if (poolObjectsList.Count != 0)
        {
            for (int i = 0; i < poolObjectsList.Count; i++)
            {
                if (!poolObjectsList[i].activeInHierarchy)  //if pool ojbect is not active then return the game object
                {
                    return poolObjectsList[i];  //return from list of pool objects
                }
            }
        }
            GameObject tmp = (GameObject)Instantiate(poolObject);  //cast poolObject as gameobject
            tmp.SetActive(false);  //set object as not active as default
            poolObjectsList.Add(tmp);  //add the inactive object to the pool object list
            return tmp;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
