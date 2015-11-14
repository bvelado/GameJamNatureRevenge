using UnityEngine;
using System.Collections;

/// <summary>
/// Permet de faire spawn des Items
/// </summary>
public class ItemSpawner : MonoBehaviour {

    static ItemSpawner instance;
    static public ItemSpawner Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void RespawnAfter(float respawnAfterSeconds, GameObject item)
    {
        StartCoroutine(SpawnItem(respawnAfterSeconds, item));
    }

    IEnumerator SpawnItem(float respawnAfterSeconds, GameObject itemObject)
    {
        yield return new WaitForSeconds(respawnAfterSeconds);
        //Item item = ((GameObject)Instantiate(itemObject, itemLocation, Quaternion.identity)).GetComponent<Item>();

        itemObject.transform.position = itemObject.GetComponent<Item>().spawnPointPosition;
        itemObject.transform.rotation = itemObject.GetComponent<Item>().spawnPointRotation;
        itemObject.SetActive(true);
    }
}
