using UnityEngine;

public class Lampadaire : MonoBehaviour {
    void OnTriggerEnter(Collider col)
    {
        // Heal le joueur
        if(col.tag == "Player")
        {
            col.GetComponent<Character>().Heal();
        }
    }
}
