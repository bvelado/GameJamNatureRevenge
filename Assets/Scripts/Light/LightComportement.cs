using UnityEngine;
using System.Collections;

public class LightComportement : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>().isPlaying)
            {
                GameObject.FindGameObjectWithTag("Musique2").GetComponent<AudioSource>().Play();
                GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>().Stop();
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("Musique2").GetComponent<AudioSource>().isPlaying)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>().Play();
                GameObject.FindGameObjectWithTag("Musique2").GetComponent<AudioSource>().Stop();
            }
        }
    }
}