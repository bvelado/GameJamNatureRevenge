using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class testPlayer : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Debug.Log("touché");
        }
    }
}
