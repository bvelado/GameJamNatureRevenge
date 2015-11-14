using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventaire : MonoBehaviour {


	private List<GameObject> objets = new List<GameObject>();

	public void AddItem(GameObject obj){
		objets.Add(obj);
	}

	public void RemoveItem(GameObject obj){
		objets.Remove (obj);
	}

	public void TryUseItems(){
		foreach (GameObject objet in objets){
			objet.GetComponent<Item>().Use();
		}
	}
}
