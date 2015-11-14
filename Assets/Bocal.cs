using UnityEngine;
using System.Collections;

public class Bocal : Item {
    public override void Use()
    {
        // Check si Lucioles en face de lui

        // Si lucioles, remplit le bocal
        // Désactive l'Item Lucioles
    }

    void OnTriggerEnter(Collider col)
    {
        // Ajoute à l'inventaire
        //if (col.tag == "Joueur") {
        //
        //}
    }
}
