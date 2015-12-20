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
    [HideInInspector]
    public bool isLighting;
    private bool dying;

	private float speed;
	private float course;

    public int _maxHp, _maxLives;
    [HideInInspector]
    public int _hp, _lives;

	private bool touched;
	
	// Use this for initialization
	void Start ()
	{
		controller = transform.GetComponent<CharacterController>();
        _hp = _maxHp;
        _lives = _maxLives;
		speed = 1.0f;
		course = 1.0f;
        picking = false;
        isLighting = true;
        dying = false;
        StartCoroutine(refreshHeal());
		Cursor.visible = false;

        HUD.Instance.InitHP(_maxHp);
        HUD.Instance.InitLives();
    }

    

    IEnumerator refreshHeal()
    {
        while (_lives > -1)
        {
            if (isLighting)
            {
                if (_hp < _maxHp)
                _hp+=6;
            }
            else
            {
                _hp -= 4;
                if (_hp < 1)
                {
                    Debug.Log("VIES AVANT LA REDUCTION = " + _lives);
                    _lives--;
                    Debug.Log("VIES APRES LA REDUCTION = " + _lives);
                    HUD.Instance.DecreaseLive();
                    Debug.Log("VIES APRES LE HUD = " + _lives);
                    if (_lives > 0)
                    {
                        // Perd 1 vie
                        _hp = _maxHp;
                        Debug.Log("PERTE D'UNE VIE");

                        if(_lives == 2 || _lives == 1)
                        {
                            Debug.Log("VIES = " + _lives);
                            mutation(_lives);
                        }
                        
                    }
                    else if(_lives == 0)
                    {
                        dying = true;
                    }
                }
            }
            HUD.Instance.UpdateHP(_hp);
            yield return new WaitForSeconds(0.5f);
        }
	}
	
    void mutation(int lives)
    {
        Debug.Log("Fonction mutation");
        string stade;

        //Definition du stade de mutation
        if(lives == 2)
        {
            stade = "Stade1";
        }
        else
        {
            stade = "Stade2";
        }

        Transform branches = this.transform.Find("Branches").FindChild(stade);

        //Aparition des branches
        for(int i=0; i < branches.childCount; i++)
        {
            branches.GetChild(i).GetComponent<SkinnedMeshRenderer>().enabled = true;
        }

    }

    //FONCTION ENVOI GAMEOVER
    
    
    public void setGameOver()
    {
        //TODO /!\ Dans la fonction declencher la fonction GameOver de la classe Globale au jeu
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

        if(dying)
        {
			StartCoroutine(Mort ());
        }

		if(touched)
		{
			this.transform.GetComponent<Animation>().CrossFade("hit");
		}

		if (moveDirection != Vector3.zero && !picking) {
			this.transform.GetComponent<Animation> ().CrossFade ("Walk");
			lastMoveDirection = moveDirection;
			
			moveDirection.y -= 0.2f * 3;
			controller.Move (moveDirection * 0.3f * speed * course);
			transform.FindChild ("Armature").FindChild ("Base").rotation = Quaternion.LookRotation (lastMoveDirection);
		} else if(!picking && !usingItem &&!dying &&!touched) {
			this.transform.GetComponent<Animation> ().CrossFade ("Iddle");
		}
		if (Input.GetButton ("Course")) {
			course = 1.8f; //On court
			this.transform.GetComponent<Animation> ().CrossFade ("Run");
		} else if (Input.GetButtonUp ("Course")) {
			course = 1.0f; //On marche
		}
		if (Physics.Raycast (transform.position, new Vector3 (0, 1, 0), out hit, 9)) {
			if (hit.collider.tag == "HautesHerbes") {
				speed = 0.6f;
			} else {
				speed = 1.0f;
			}
		}
		if (Input.GetButtonDown ("Utiliser")) {
			GetComponent<Inventaire>().TryUseItems();
		}

        if(Input.GetButtonDown("Lancer"))
        {
            GetComponent<Inventaire>().TryThrowBocalLucioles();
        }
	}

	public void RamasserObjet(GameObject obj){
        //this.transform.GetComponent<Animation> ().CrossFade ("Pick");
        picking = true;
        GetComponent<Inventaire>().AddItem(obj);
        Item.ItemType type = obj.GetComponent<Item>().Type;
        HUD.Instance.AddItemHUD(type);

        obj.transform.SetParent(transform);
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

	public void endTouched()
	{
		touched = false;
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
            _hp -= hp*5;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "ZonePlante")
        {
            col.GetComponent<PlanteCarnivore>().becomeAgressive();
        }

        if (col.gameObject.tag == "tuto")
        {
            HUD.Instance.displayTuto(col.gameObject.name);
        }

    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "tuto")
        {
            HUD.Instance.displayTuto("");
        }
    }

	IEnumerator Mort(){
		this.transform.GetComponent<Animation>().CrossFade("death2");
		HUD.Instance.showDeathMessage();
		yield return new WaitForSeconds (4.0f);
		Application.LoadLevel("Level1");
	}

	//PARTIE SON
	
	public void song(AudioClip song)
	{
		GetComponent<AudioSource>().PlayOneShot(song);
	}
	
	void OnTriggerEnter(Collider col)
	{
		Debug.Log("COLLISION !!!!");
		Debug.Log("TAG = " + col.gameObject.tag);
		
		if(col.gameObject.tag == "Enemy")
		{
			touched = true;
		}
		
		
	}
	


}