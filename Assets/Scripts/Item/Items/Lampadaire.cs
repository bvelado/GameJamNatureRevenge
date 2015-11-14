using UnityEngine;

[ExecuteInEditMode]
public class Lampadaire : MonoBehaviour {
    public float radius;

    
    void Update()
    {
        GetComponent<CapsuleCollider>().radius = radius;
        GetComponent<Light>().range = radius;
    }

}
