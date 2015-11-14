using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	private CharacterController controller;
	private Vector3 moveDirection;
	
	// Use this for initialization
	void Start ()
	{
		controller = transform.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Droite
		if(Input.GetKey(KeyCode.RightArrow))
		{
			moveDirection = new Vector3(0.5f,0,0);
			//moveDirection *= speed;
			
		}
		//Gauche
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			moveDirection = new Vector3(-0.5f, 0, 0);
		}
		//Haut
		if (Input.GetKey(KeyCode.UpArrow))
		{
			moveDirection = new Vector3(0, 0, 0.5f);
		}
		//Bas
		if (Input.GetKey(KeyCode.DownArrow))
		{
			moveDirection = new Vector3(0, 0, -0.5f);
		}
		//HautDroit
		if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
		{
			moveDirection = new Vector3(0.5f, 0, 0.5f);
		}
		
		//HautGauche
		if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
		{
			moveDirection = new Vector3(-0.5f, 0, 0.5f);
		}
		
		//BasDroit
		if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
		{
			moveDirection = new Vector3(0.5f, 0, -0.5f);
		}
		
		//BasGauche
		if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
		{
			moveDirection = new Vector3(-0.5f, 0, -0.5f);
		}
		
		//Pas bougé
		if(!Input.anyKey)
		{
			moveDirection = new Vector3(0, 0, 0);
		}
		moveDirection.y -= 0.2f * 3;
		controller.Move(moveDirection * 0.3f);
		
	}
}