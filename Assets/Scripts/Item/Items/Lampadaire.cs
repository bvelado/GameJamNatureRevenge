using UnityEngine;

public class Lampadaire : MonoBehaviour {
    public float radius = 4.0f;
    
    void Start()
    {
        GetComponent<CapsuleCollider>().radius = radius;
        GetComponent<Light>().range = radius;
    }
}
