using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    //used for the scrolling background
    Material myMaterial;

    Vector2 offsetBackground;

    public float velocityX; //speed background moves in x direction


    // Start is called before the first frame update
    void Start()
    {
        offsetBackground = new Vector2(velocityX, 0);
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offsetBackground * Time.deltaTime;      //offset is multiplied by delta time
    }

    private void Awake()
    {
        myMaterial = GetComponent<Renderer>().material;     //get component Material
    }
}
