using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour {

	public enum ItemType
	{
		Bocal,
        BocalLucioles,
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

    // Vrai = essaye de repop si inactif
    bool tryRespawn = false;
    // Vrai = Est dans l'inventaire du joueur et ne peut pas être ramassé
    // Vrai = Son renderer est désactivé
    bool isPickedUp = false;

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
                if ((hit.collider.tag=="PlanteCraintive") && (Type == ItemType.Bocal)){
					Debug.Log ("Vous pouvez utiliser l'objet");
                    HUD.Instance.RemoveItemHUD(Type);
                } else if ((hit.collider.tag == "PortailDoor") && (Type == ItemType.PiedDeBiche)) {
                    Debug.Log("Ouverture du portail");
                    player.GetComponent<Character>().startUsingItem();

                    StartCoroutine(AnimPortailAndDepop(hit.transform.parent.parent)); 
				}else if ((hit.collider.tag == "Ronces") && (Type == ItemType.Torche)) {
					Debug.Log("Ca brule");
                    StartCoroutine(DepopRonces(player, hit));
                    
				}
			}
		}
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player" && !isPickedUp) {
			col.GetComponent<Character>().RamasserObjet(gameObject);
            StartCoroutine(WaitAndDepop(1.5f));
        }
    }

    private IEnumerator WaitAndDepop(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        transform.FindChild("Model").gameObject.SetActive(false);
        tryRespawn = false;
        isPickedUp = true;
    }



    //---------------------------------- PORTAIL
    private IEnumerator AnimPortailAndDepop(Transform portail)
    {
        yield return new WaitForSeconds(1.5f);
        // Anime le portail ???
        portail.GetComponent<Animation>().Play();
        Debug.Log("Portail ouvert");
        // Désactive le collider du portail
        while(portail.GetComponent<Animation>().isPlaying)
        {
            hit.collider.gameObject.gameObject.SetActive(false);
            tryRespawn = true;
            gameObject.SetActive(false);
            HUD.Instance.RemoveItemHUD(Type);
            yield return null;
        }

        yield return null;
    }


    //---------------------------------- RONCES
    private IEnumerator DepopRonces(GameObject player, RaycastHit hit)
    {
        player.GetComponent<Character>().startUsingItem();
        yield return new WaitForSeconds(1.5f);

        // Anime le feu des ronces
        hit.collider.transform.FindChild("FireParticles").gameObject.SetActive(true);
        hit.collider.transform.FindChild("FireParticles").GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(5f);
        Destroy(hit.collider.gameObject);
       

        yield return null;
    }


    void OnDisable()
    {
        if(tryRespawn)
        {
            ItemSpawner.Instance.RespawnAfter(respawnAfterSeconds, gameObject);
        }
    }
}
