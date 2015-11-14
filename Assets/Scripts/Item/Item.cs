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

    void Start()
    {
        spawnPointPosition = transform.position;
        spawnPointRotation = transform.rotation;
    }

    public virtual void Use()
    {
		player = GameObject.Find ("Player");
		if (Physics.Raycast (player.transform.position, player.GetComponent<Character>().lastMoveDirection, out hit, 9)) {
			if (hit.distance<10){
				if ((hit.collider.tag=="Lucioles") && (Type == ItemType.Bocal)){
					Debug.Log ("Vous pouvez utiliser l'objet");
				} else if ((hit.collider.tag == "Portail") && (Type == ItemType.PiedDeBiche)) {
                    Debug.Log("Ouverture du portail");
                }
			}
		}
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player") {
            Debug.Log(Type.ToString() + " rammassé.");
			col.GetComponent<Character>().RamasserObjet(gameObject);
			gameObject.SetActive(false);
		}
    }

    void OnDisable()
    {
        
		ItemSpawner.Instance.RespawnAfter(respawnAfterSeconds, gameObject);
    }
}
