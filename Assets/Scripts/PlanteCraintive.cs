using UnityEngine;
using System.Collections;

public class PlanteCraintive : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "BocalLucioles") {
			Debug.Log ("Bocal a tué la plante");
			Destroy(gameObject);
		}
	}

}
