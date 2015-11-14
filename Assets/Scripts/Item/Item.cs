﻿using UnityEngine;
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
	
	public float respawnAfterSeconds = 10.0f;
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
			col.GetComponent<Inventaire>().ramassageObjet(gameObject);
			OnDisable();
			gameObject.SetActive(false);
		}
    }

    void OnDisable()
    {
		ItemSpawner.Instance.RespawnAfter(respawnAfterSeconds, gameObject);
    }
}
