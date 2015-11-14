using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour {

	public enum ItemType
	{
		Bocal,
		Hache,
		PiedDeBiche,
		Torche
	};
	public ItemType Type;
	
	public float respawnAfterSeconds = 30.0f;
    [HideInInspector]
    public Vector3 spawnPointPosition;
    [HideInInspector]
    public Quaternion spawnPointRotation;

	private RaycastHit hit;
	private GameObject player;

    bool tryRespawn = false;

    void Start()
    {
        spawnPointPosition = transform.position;
        spawnPointRotation = transform.rotation;
    }

    public void Use()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (Physics.Raycast (player.transform.position, player.transform.forward, out hit, 9f)) {
			if (hit.distance<10){
                if ((hit.collider.tag=="Lucioles") && (Type == ItemType.Bocal)){
					Debug.Log ("Vous pouvez utiliser l'objet");
				} else if ((hit.collider.tag == "PortailDoor") && (Type == ItemType.PiedDeBiche)) {
                    Debug.Log("Ouverture du portail");
                    hit.collider.gameObject.SetActive(false);
                    tryRespawn = true;
                    gameObject.SetActive(false);
                }
			}
		}
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player") {
			col.GetComponent<Character>().RamasserObjet(gameObject);
            StartCoroutine(Wait(1.5f));
        }
    }

    private IEnumerator Wait(float seconds)
    {
        Debug.Log("waiting");
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
        tryRespawn = false;
    }

    void OnDisable()
    {
        if(tryRespawn)
        {
            ItemSpawner.Instance.RespawnAfter(respawnAfterSeconds, gameObject);
        }
    }
}
