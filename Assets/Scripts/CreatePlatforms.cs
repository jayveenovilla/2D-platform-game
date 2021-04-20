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

    private float minHeightPlatform;
    public Transform maxHeightPlatformLimit;
    private int maxHeightPlatform;
    public int maxHeightPlatformChange;
    private float changeHeight;

    private CreateCoin myCreateCoin;
    public float randomizeCoins;
    public float randomizeSpikes;
    public float randomizeSpider;
    public float randomizeSnake;
    public PoolObjects myPoolSpike;
    public PoolObjects myPoolSpider;
    public PoolObjects myPoolSnake;

    private float positionXSpike;
    private float positionXSpider;
    private float positionXSnake;

    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = Platform.GetComponent<BoxCollider2D>().size.x;  //width of platform is the width of the Box Collider
        platformWidths = new float[arrObjectPool.Length]; //create new platformWidth array as same size of arrPlatform

        for(int i = 0; i < arrObjectPool.Length; i++)
        {
            platformWidths[i] = arrObjectPool[i].poolObject.GetComponent<BoxCollider2D>().size.x;    //width of platform is the width of the Box Collider of the object pool
        }

        minHeightPlatform = transform.position.y;   //starting height of platforms
        maxHeightPlatform = (int)maxHeightPlatformLimit.position.y;  //starting height limit of platforms

        myCreateCoin = FindObjectOfType<CreateCoin>();      //find object that create coins
    }

    // Update is called once per frame
    void Update()
    {
     if(transform.position.x < createPlatform.position.x)  //generates new platform if current position is less than the creat platform position
        {
            //Debug.Log("SingletonCurrentScore: " + GameManagerSingleton.Instance.player.currentScore);
            int num;
            int numMax;
            //difficulty of platform height increases with current high score
            int heightPlatformChange=0;
            if (GameManagerSingleton.Instance.player.currentScore > 250)
            {
                heightPlatformChange = 1;
            }

            if (GameManagerSingleton.Instance.player.currentScore > 500)
            {
                heightPlatformChange = 2;
            }

            if (GameManagerSingleton.Instance.player.currentScore > 1000)
            {
                heightPlatformChange = 3;
            }

            //Debug.Log("Platform Height: " + heightPlatformChange);

            distanceFromPlatform = Random.Range(distanceFromPlatformMin, distanceFromPlatformMax);  //randomize distance between platforms

            selectPlatform = Random.Range(0, arrObjectPool.Length);   //select platform randomly

            changeHeight = transform.position.y + Random.Range(heightPlatformChange, -(heightPlatformChange+1));  //randomly change the height of the platforms
            
            if(changeHeight > maxHeightPlatform)    //prevents the platforms from generating below the starting camera position
            {
                changeHeight = maxHeightPlatform;
            }
            else if(changeHeight < minHeightPlatform)
            {
                changeHeight = minHeightPlatform;
            }

            //Debug.Log("Change Height to: " + changeHeight);

            transform.position = new Vector3(transform.position.x + (platformWidths[selectPlatform]/2) + distanceFromPlatform, changeHeight, transform.position.z);  //position of new platform

            

            //Instantiate(/*Platform*/arrPlatform[selectPlatform], transform.position, transform.rotation); //creates new platform at new position based on randomly selected platform
            GameObject tmpPlatform = arrObjectPool[selectPlatform].GetPoolObjectsList();  //creates new platform at new position from object pool list

            tmpPlatform.transform.position = transform.position;  //set position of the new platform to calculated position of new platform
            tmpPlatform.transform.rotation = transform.rotation;
            tmpPlatform.SetActive(true);    //plaform default is inactive, activate new platform

            if(Random.Range(0f, 100f) < randomizeCoins)     //randomize coin spawn
            {
                myCreateCoin.GenerateCoin(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            if(platformWidths[selectPlatform] >= 5f)        //only spawn spider enemy or traps on platform width 5 or greater
            {
                numMax = 1;     //if high score less than 1000 or greater then spawn either spike or spiders
                num = 0;

                if (GameManagerSingleton.Instance.player.currentScore > 250)   //if current score 250 or greater then start spawn spike
                {
                    numMax = 1;
                }

                if (GameManagerSingleton.Instance.player.currentScore > 500)   //if current score 500 or greater then start spawn spider
                {
                    numMax = 2;
                }

                if (GameManagerSingleton.Instance.player.currentScore > 1000)   //if current score 1000 or greater then start spawn snake
                {
                    numMax = 3;
                }

                num = Random.Range(1, numMax + 1);  //int Range(int minInclusive, int maxExclusive); 
                //Debug.Log("num: " + num);
                //Debug.Log("numMax: " + numMax);
                if (num == 1 && GameManagerSingleton.Instance.player.currentScore > 250)    //either spawn a spike trap, spider or a snake
                {
                    if (Random.Range(0f, 100f) < randomizeSpikes)   //randomize spike spawn
                    {
                        GameObject tripleSpike = myPoolSpike.GetPoolObjectsList();

                        positionXSpike = Random.Range(-platformWidths[selectPlatform] / 2 + 2f, platformWidths[selectPlatform] / 2 - 2f);   //spawn randomly on platform
                        Vector3 positionSpike = new Vector3(positionXSpike, 0.5f, 0f);  //0f spawns in middle of platform

                        tripleSpike.transform.position = transform.position + positionSpike;
                        tripleSpike.transform.rotation = transform.rotation;
                        tripleSpike.SetActive(true);
                    }
                }
                if (num == 2 && GameManagerSingleton.Instance.player.currentScore > 500)
                {
                    if (Random.Range(0f, 100f) < randomizeSpider)   //randomize spider spawn
                    {
                        GameObject jumpingSpider = myPoolSpider.GetPoolObjectsList();

                        positionXSpider = Random.Range(-platformWidths[selectPlatform] / 2 + 2f, platformWidths[selectPlatform] / 2 - 2f);  //spawn randomly on platform
                        Vector3 positionSpider = new Vector3(positionXSpider, 0.5f, 0f);  //0f, 0.5f, 0f spawns in middle of platform

                        jumpingSpider.transform.position = transform.position + positionSpider;
                        jumpingSpider.transform.rotation = transform.rotation;
                        jumpingSpider.SetActive(true);
                    }
                }
                if (num == 3 && GameManagerSingleton.Instance.player.currentScore > 1000)
                {
                    if (Random.Range(0f, 100f) < randomizeSnake)   //randomize snake spawn
                    {
                        GameObject movingSnake = myPoolSnake.GetPoolObjectsList();

                        positionXSnake = Random.Range(-platformWidths[selectPlatform] / 2 + 2f, platformWidths[selectPlatform] / 2 - 2f);  //spawn randomly on platform
                        Vector3 positionSnake = new Vector3(positionXSnake, 0.5f, 0f);  //0f, 0.5f, 0f spawns in middle of platform

                        movingSnake.transform.position = transform.position + positionSnake;
                        movingSnake.transform.rotation = transform.rotation;
                        movingSnake.SetActive(true);
                    }
                }
            }


            transform.position = new Vector3(transform.position.x + (platformWidths[selectPlatform] / 2), transform.position.y, transform.position.z);  //position of new platform

        }
    }
}
