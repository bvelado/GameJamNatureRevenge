using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

	public string level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.name == "Player") {
			Application.LoadLevel (level);
		}
	}
}
