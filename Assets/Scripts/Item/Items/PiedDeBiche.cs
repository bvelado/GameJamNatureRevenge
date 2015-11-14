using UnityEngine;
using System.Collections;

public class PiedDeBiche : Item {

    void Awake()
    {
        
    }

    public override void Use()
    {
        // Check si Portail en face de lui
        
        // Si portail, ouvre le portail
    }

    void OnTriggerEnter(Collider col)
    {
        // Ajoute à l'inventaire
        //if (col.tag == "Joueur") {
        //
        //}
    }
}
