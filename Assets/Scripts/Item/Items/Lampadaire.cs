using UnityEngine;

public class Lampadaire : MonoBehaviour {
    void OnTriggerEnter(Collider col)
    {
        // Heal le joueur
        if(col.tag == "Joueur")
        {
            col.GetComponent<Character>().Heal();
        }
    }
}
