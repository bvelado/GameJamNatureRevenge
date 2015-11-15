﻿using UnityEngine;
using System.Collections.Generic;

public class Inventaire : MonoBehaviour {


	private List<GameObject> objets = new List<GameObject>();

    public void Awake()
    {
        List<GameObject> objets = new List<GameObject>();
    } 

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

    public void TryThrowBocalLucioles()
    {
        foreach(GameObject objet in objets)
        {
            Debug.Log("Pas lancé");
            if (objet.GetComponent<Item>().Type == Item.ItemType.BocalLucioles)
            {
                Debug.Log("Lancé");
                objet.GetComponent<Item>().Throw();
            }
        }
    }
}
