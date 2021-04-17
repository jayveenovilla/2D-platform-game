using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipScript : MonoBehaviour
{
    public static AudioClip soundPlayerJump;
    public static AudioClip soundCoin;
    public static AudioClip soundDeath;

    public static AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        soundPlayerJump = Resources.Load<AudioClip>("apricotjumpbounce-sheepbounce2");
        soundCoin = Resources.Load<AudioClip>("Picked Coin Echo");
        soundDeath = Resources.Load<AudioClip>("pain1");

        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlayAudioClip(string value)
    {
        switch (value)
        {
            case "apricotjumpbounce-sheepbounce2":
                myAudioSource.PlayOneShot(soundPlayerJump);
                break;
            case "Picked Coin Echo":
                myAudioSource.PlayOneShot(soundCoin);
                break;
            case "pain1":
                myAudioSource.PlayOneShot(soundDeath);
                break;
        }
    }
}
