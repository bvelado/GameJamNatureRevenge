using UnityEngine;
using System.Collections;

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

    void Start()
    {
        spawnPointPosition = transform.position;
        spawnPointRotation = transform.rotation;
    }
	
	public void Update () {

	}

    public virtual void Use()
    {
		player = GameObject.Find ("Player");
		if (Physics.Raycast (player.transform.position, player.GetComponent<Character>().lastMoveDirection, out hit, 9)) {
			if (hit.distance<10){
				if ((hit.collider.tag=="r") && (Type == ItemType.Bocal)){
					Debug.Log ("Vous pouvez utiliser l'objet");
				}
			}
		}
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player") {
			col.GetComponent<Character>().RamasserObjet(gameObject);
         //   col.GetComponent<Character().
			col.GetComponent<Inventaire>().ramassageObjet(gameObject);

            StartCoroutine(Wait(1.5f));

            

        }
    }

    private IEnumerator Wait(float seconds)
    {
        Debug.Log("waiting");
        yield return new WaitForSeconds(seconds);
        OnDisable();
        gameObject.SetActive(false);
        Debug.Log("wait end");
    }

    void OnDisable()
    {
       ItemSpawner.Instance.RespawnAfter(respawnAfterSeconds, gameObject);      
    }
}
