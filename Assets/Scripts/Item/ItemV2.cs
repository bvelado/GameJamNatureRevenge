using System;
using UnityEngine;

public class ItemV2 : MonoBehaviour, IInventoryAttachable {

    public ItemState _state;

    public GameObject _model, _body;

    public virtual void Awake() {
        
    }

    public virtual void Start () {
        
    }

    public void Update () {
        _state.Update();
	}

    public void Use()
    {
        _state.Use();
    }

    public virtual void OnTriggerEnter(Collider col)
    {
        
    }

    public void Attach(Inventory inventory)
    {
        inventory.AddItem(this);
    }

    public void Detach()
    {
        GameObject.FindWithTag("Player").GetComponent<Inventory>().RemoveItem(this);
    }

}
