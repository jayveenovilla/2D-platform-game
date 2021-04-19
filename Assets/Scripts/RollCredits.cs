using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollCredits : MonoBehaviour
{
    public Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();      //get animator
        myAnimator.Play("Credits", 0, 0);       //play the Credits animation

    }

    // Update is called once per frame
    void Update()
    {
        myAnimator.Play("Credits",0,0);
    }
}
