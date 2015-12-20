using UnityEngine;
using System.Collections;

public class LightedTorchItemState : ItemState
{

    public override void Init(ItemV2 item)
    {
        base.Init(item);

        float maxIntensity = _item._model.GetComponent<Light>().intensity;

        _item.StartCoroutine(Decay(_item._model.GetComponent<Light>(), maxIntensity, 10.0f));
    }

    IEnumerator Decay(Light light, float maxIntensity, float duringSeconds)
    {
        for (int i = (int)duringSeconds; i > -1; i--)
        {
            light.intensity = (i / duringSeconds) * maxIntensity;
            yield return new WaitForSeconds(1.0f);
        }
        ChangeState(new ExtinguishedTorchItemState());
    }
}
