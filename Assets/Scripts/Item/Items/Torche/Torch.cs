using UnityEngine;
using System.Collections;

public class Torch : ItemV2 {

    public override void Start()
    {
        if (_state == null)
        {
            _state = new LightedTorchItemState();
            _state.Init(this);
        }
    }
}
