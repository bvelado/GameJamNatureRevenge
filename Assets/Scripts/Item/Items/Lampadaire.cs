using UnityEngine;

[ExecuteInEditMode]
public class Lampadaire : MonoBehaviour {
    public float radius = 4.0f;

    
    void Update()
    {
        GetComponent<CapsuleCollider>().radius = radius;
        GetComponent<Light>().range = radius;
    }

}
