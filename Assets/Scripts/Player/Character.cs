using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	private CharacterController controller;
	private Vector3 moveDirection;
	private Vector3 lastMoveDirection;
	private float horizMove;
	private float vertMove;

    public int _maxHp, _maxLives;
    public int _hp, _lives;
	
	// Use this for initialization
	void Start ()
	{
		controller = transform.GetComponent<CharacterController>();
        _hp = _maxHp;
        _lives = _maxLives;
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

    public void Heal()
    {
        StartCoroutine(HealOneFloor());
    }

    IEnumerator HealOneFloor()
    {
        // Heale un pallier entier de vie
        while(_hp < _maxHp)
        {
            _hp++;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return null;
    }

    public void LoseHP(int hp)
    {
        if(_hp - hp < 0)
        {
            if(_lives < 0)
            {
                // GAME OVER
            } else
            {
                // Perd 1 vie
                _hp = _maxHp + (_hp - hp);
                _lives--;
            }
        } else
        {
            _hp -= hp;
        }
    }

}