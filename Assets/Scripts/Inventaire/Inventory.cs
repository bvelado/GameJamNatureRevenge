using UnityEngine;
using System.Collections.Generic;

public class Inventory {


	private List<ItemV2> _items = new List<ItemV2>();

    public void Awake()
    {
        _items = new List<ItemV2>();
    } 

	public void AddItem(ItemV2 item){
		_items.Add(item);
	}

	public void RemoveItem(ItemV2 item){
        _items.Remove (item);
	}

	public void TryUseItems(){
		foreach (ItemV2 item in _items){
			item.GetComponent<ItemV2>().Use();
		}
	}
}
