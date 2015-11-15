using UnityEngine;
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
            if(objet.GetComponent<Item>().Type == Item.ItemType.BocalLucioles)
            {
                objet.GetComponent<Item>().Throw();
            }
        }
    }
}
