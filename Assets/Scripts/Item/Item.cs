using UnityEngine;

public class Item : MonoBehaviour {

    public float respawnAfterSeconds = 5.0f;
    [HideInInspector]
    public Vector3 spawnPoint;

    void Awake()
    {
        spawnPoint = transform.position;
    }
	
	public void Update () {
        handleInput();
	}

    public virtual void handleInput()
    {
        // Bouchon pour test
        // Remplacer par une detection de collision : OnTriggerEnter()
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void onPickedUp()
    {
        // Behaviour
    }

    void OnTriggerEnter(Collider col)
    {
        onPickedUp();
    }

    void OnDisable()
    {
        ItemSpawner.Instance.RespawnAfter(respawnAfterSeconds, gameObject);
    }
}
