using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	private CharacterController controller;
	private Vector3 moveDirection;
	private Vector3 lastMoveDirection;
	private float horizMove;
	private float vertMove;
	
	// Use this for initialization
	void Start ()
	{
		controller = transform.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		horizMove=Input.GetAxis ("Horizontal");
		vertMove=Input.GetAxis ("Vertical");
		moveDirection = new Vector3(horizMove*0.5f,0,vertMove*0.5f);

		
		if (moveDirection != Vector3.zero) {
			lastMoveDirection = moveDirection;
		}

		moveDirection.y -= 0.2f * 3;
		controller.Move(moveDirection * 0.3f);
		transform.FindChild("character").rotation = Quaternion.LookRotation(lastMoveDirection);
		
	}
}