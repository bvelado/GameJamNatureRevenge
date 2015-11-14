using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventaire : MonoBehaviour {


	private List<GameObject> objets = new List<GameObject>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ramassageObjet(GameObject obj){
		objets.Add(obj);
	}

	public void deleteObjet(GameObject obj){
		objets.Remove (obj);
	}

	public void useObject(){
		int tailleListe = objets.Count;
		foreach (GameObject objet in objets){
			objet.GetComponent<Item>().Use();
		}
	}
}
