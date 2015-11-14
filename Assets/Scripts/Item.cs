using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public float respawnAfterSeconds = 5.0f;
    ItemSpawner spawner;
	
	void Update () {
        // Bouchon pour test
        // Remplacer par une detection de collision : OnTriggerEnter()
        if (Input.GetKeyDown(KeyCode.A)) {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        spawner.RespawnAfter(respawnAfterSeconds);
    }

    public void SetItemSpawner(ItemSpawner itemSpawner)
    {
        spawner = itemSpawner;
    }
}
