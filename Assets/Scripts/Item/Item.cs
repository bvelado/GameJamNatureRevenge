using UnityEngine;

public class Item : MonoBehaviour {

    public float respawnAfterSeconds = 5.0f;
    [HideInInspector]
    public Vector3 spawnPointPosition;
    [HideInInspector]
    public Quaternion spawnPointRotation;

    void Awake()
    {
        
    }

    void Start()
    {
        spawnPointPosition = transform.position;
        spawnPointRotation = transform.rotation;
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

    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<Character>() != null)
        {
            col.GetComponent<Character>().PickItem(Item);
        }
    }

    void OnDisable()
    {
        ItemSpawner.Instance.RespawnAfter(respawnAfterSeconds, gameObject);
    }
}
