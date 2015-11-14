using UnityEngine;
using System.Collections;

/// <summary>
/// Permet de faire spawn des Items
/// </summary>
public class ItemSpawner : MonoBehaviour {

    public GameObject objectPrefab;

	void Start () {
        // Spawn l'item instantanement
        StartCoroutine(SpawnItem(0.0f));
	}

    public void RespawnAfter(float respawnAfterSeconds)
    {
        StartCoroutine(SpawnItem(respawnAfterSeconds));
    }

    IEnumerator SpawnItem(float respawnAfterSeconds)
    {
        yield return new WaitForSeconds(respawnAfterSeconds);
        Item item = ((GameObject)Instantiate(objectPrefab, transform.position, Quaternion.identity)).GetComponent<Item>();
        item.GetComponent<Item>().SetItemSpawner(this);
    }
}
