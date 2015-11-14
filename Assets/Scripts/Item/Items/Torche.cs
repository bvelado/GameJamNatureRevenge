using UnityEngine;
using System.Collections;

public class Torche : Item {

    public float decayInSeconds = 70.0f;
    float maxIntensity;

    void Start()
    {
        maxIntensity = GetComponent<Light>().intensity;
    }

    IEnumerator Decay(float duringSeconds)
    {
        Light light = GetComponent<Light>();
        for(int i = (int)duringSeconds; i > -1; i--)
        {
            light.intensity = (i / duringSeconds) * maxIntensity;
            yield return new WaitForSeconds(1.0f);
        }
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        GetComponent<Light>().intensity = maxIntensity;
    }
}
