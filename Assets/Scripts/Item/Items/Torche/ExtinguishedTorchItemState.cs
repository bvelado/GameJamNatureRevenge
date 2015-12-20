using UnityEngine;
using System.Collections;

public class ExtinguishedTorchItemState : ItemState
{
    public override void Use()
    {
        base.Use();

        //ChangeState(new LightedTorchItemState(_item));
    }
}
