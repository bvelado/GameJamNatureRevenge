using UnityEngine;
using System.Collections;

public class PlanteCarnivore : MonoBehaviour {


    private bool agressive;
    private bool detection;

	// Use this for initialization
	void Start ()
    {
        agressive = false;
        detection = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(agressive && !detection)
        {
            this.transform.GetComponent<Animation>().CrossFade("Attack");
        }
        else if(detection)
        {
            this.transform.GetComponent<Animation>().CrossFade("Detect");
        }
	}

    public void StopDetect()
    {
        detection = false;
    }

    public void becomeAgressive()
    {
        agressive = true;
    }

    public void transition()
    {
        agressive = false;
        detection = true;
    }


    }
