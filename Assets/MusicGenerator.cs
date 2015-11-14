using UnityEngine;
using System.Collections;
using System;

public class MusicGenerator : MonoBehaviour
{

    // Use this for initialization
    public static GameObject music;



    // Use this for initialization
    void Start()
    {
        var musicTemp = GameObject.FindGameObjectWithTag("GameController");
        if (musicTemp)
        {
            music = musicTemp;
            music.GetComponent<AudioSource>().Play();
        }
    }
}
