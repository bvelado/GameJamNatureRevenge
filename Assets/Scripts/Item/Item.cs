using UnityEngine;

public class Item : MonoBehaviour {

    public float respawnAfterSeconds = 5.0f;
    [HideInInspector]
    public Vector3 spawnPointPosition;
    [HideInInspector]
    public Quaternion spawnPointRotation;

    void Start()
    {
        spawnPointPosition = transform.position;
        spawnPointRotation = transform.rotation;
    }
	
	public void Update () {

	}

    public virtual void Use()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player") {
            // col.GetComponent<Character>().RammasserObjet(this); 
			gameObject.SetActive (false);
		}
    }

    void OnDisable()
    {
        ItemSpawner.Instance.RespawnAfter(respawnAfterSeconds, gameObject);
    }
}
