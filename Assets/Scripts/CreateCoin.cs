using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoin : MonoBehaviour
{
    public PoolObjects poolCoin;

    public float positionCoin;

    public void GenerateCoin(Vector3 position)
    {
        GameObject coin1 = poolCoin.GetPoolObjectsList();
        coin1.transform.position = position;
        coin1.SetActive(true);

        GameObject coin2 = poolCoin.GetPoolObjectsList();
        coin2.transform.position = new Vector3(position.x - positionCoin, position.y, position.z);
        coin2.SetActive(true);

        GameObject coin3 = poolCoin.GetPoolObjectsList();
        coin3.transform.position = new Vector3(position.x + positionCoin, position.y, position.z);
        coin3.SetActive(true);


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
