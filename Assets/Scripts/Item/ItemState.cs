using UnityEngine;
using System.Collections;

public class ItemState {

    protected ItemV2 _item;

    // Initialisation de la state de l'objet
    public virtual void Init(ItemV2 item)
    {
        _item = item;
    }

    public virtual void Update()
    {

    }

    // Cleaning des variables de la state de l'objet
    public virtual void Exit()
    {

    }

    public virtual void Use()
    {

    }

    public void ChangeState(ItemState nextState)
    {
        _item._state.Exit();
        _item._state = nextState;
        _item._state.Init(_item);
    }
}
