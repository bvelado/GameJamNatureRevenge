using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	private CharacterController controller;
	private Vector3 moveDirection;
	public Vector3 lastMoveDirection;
	private float horizMove;
	private float vertMove;
	private RaycastHit hit;

    private bool picking;
    private bool usingItem;

	private float speed;
	private float course;

    public int _maxHp, _maxLives;
    public int _hp, _lives;
	
	// Use this for initialization
	void Start ()
	{
		controller = transform.GetComponent<CharacterController>();
        _hp = _maxHp;
        _lives = _maxLives;
		speed = 1.0f;
		course = 1.0f;
        picking = false;

        HUD.Instance.InitHP(_maxHp);
        HUD.Instance.InitLives();
	}
	
	// Update is called once per frame
	void Update ()
	{
		horizMove = Input.GetAxis ("Horizontal");
		vertMove = Input.GetAxis ("Vertical");
		moveDirection = new Vector3 (horizMove * 0.5f, 0, vertMove * 0.5f);
       
        if(picking)
        {
            this.transform.GetComponent<Animation>().CrossFade("Pick");
        }

        if(usingItem)
        {
            
            this.transform.GetComponent<Animation>().CrossFade("UseItem");
        }

		if (moveDirection != Vector3.zero && !picking) {
			this.transform.GetComponent<Animation> ().CrossFade ("Walk");
			lastMoveDirection = moveDirection;
			
			moveDirection.y -= 0.2f * 3;
			controller.Move (moveDirection * 0.3f * speed * course);
			transform.FindChild ("Armature").FindChild ("Base").rotation = Quaternion.LookRotation (lastMoveDirection);
		} else if(!picking && !usingItem) {
			this.transform.GetComponent<Animation> ().CrossFade ("Iddle");
		}
		if (Input.GetButton ("Course")) {
			course = 1.5f; //On court
			this.transform.GetComponent<Animation> ().CrossFade ("Run");
		} else if (Input.GetButtonUp ("Course")) {
			course = 1.0f; //On marche
		}
		if (Physics.Raycast (transform.position, new Vector3 (0, 1, 0), out hit, 9)) {
			if (hit.collider.tag == "HautesHerbes") {
				speed = 0.7f;
			} else {
				speed = 1.0f;
			}
		}
		if (Input.GetButtonDown ("Utiliser")) {
			GetComponent<Inventaire>().TryUseItems();
		}
	}

	public void RamasserObjet(GameObject obj){
        //this.transform.GetComponent<Animation> ().CrossFade ("Pick");
        picking = true;
        GetComponent<Inventaire>().AddItem(obj);
        Item.ItemType type = obj.GetComponent<Item>().Type;
        HUD.Instance.AddItemHUD(type);
    }

    public void FinishPicking()
    {
        
        picking = false;
    }

    public bool getPicking()
    {
        return this.picking;
    }

    public void startUsingItem()
    {
        
        this.usingItem = true;
    }

    public void endUsingItem()
    {
        
        this.usingItem = false;
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