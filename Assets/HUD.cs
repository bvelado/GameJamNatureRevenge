using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

    List<Item.ItemType> currentItems;

    Stack<Image> lives;

    public Slider hpSlider;
    public Image live1, live2, live3, live4;

    public GameObject bocalImage, torcheImage, piedDeBicheImage, hacheImage;

    public Sprite bocalSprite, bocalLuciolesSprite;

	public Text DeathMessage;

    static HUD instance;
    public static HUD Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }

        currentItems = new List<Item.ItemType>();

        InitLives();
        
    }

    public void displayTuto(string tuto)
    {
        string tutoriel;

        switch(tuto)
        {
            case "Zone1": tutoriel = "Je dois partir...";
                break;
            case "Zone2": tutoriel = "Ces ténébres me pèsent...";
                break;
            case "Zone3": tutoriel = "De la lumiére ! Enfin !";
                break;
            case "Zone4": tutoriel = "Un bocal ? Je devrais pouvoir attraper ces lucioles avec ca";
                break;
            case "Zone5": tutoriel = "Qu'est ce que c'est ? Des lucioles ?";
                break;
            case "Zone6A": tutoriel = "Woah ! Quel est ce monstre ??";
                break;
            case "Zone6B": tutoriel = "Et si je lui lançais le bocal ?";
                break;
            case "Zone7": tutoriel = "Un pied de biche ! Ce sera utile a un moment donné !";
                break;
            case "Zone8A": tutoriel = "Mince c'est fermé ! Il me faut de quoi crocheter la serrure !";
                break;
            case "Zone8B": tutoriel = "Le pied de biche devrait faire l'affaire ! ";
                break;
            default: tutoriel = "";
                break;
        }

        transform.Find("Tutoriel").GetComponent<Text>().text = tutoriel;
    }

    public void InitHP(int maxHp)
    {
        Debug.Log(maxHp);
        hpSlider.maxValue = maxHp;
        hpSlider.value = maxHp;
    }

    public void InitLives()
    {
        lives = new Stack<Image>();
        lives.Push(live1);
        lives.Push(live2);
        lives.Push(live3);
        lives.Push(live4);
    }

    public void AddItemHUD(Item.ItemType itemType)
    {
        if(!currentItems.Contains(itemType))
        {
            currentItems.Add(itemType);
            switch(itemType)
            {
                case Item.ItemType.Bocal:
                    bocalImage.GetComponent<Image>().overrideSprite = bocalSprite;
                    bocalImage.SetActive(true);
                    break;

                case Item.ItemType.BocalLucioles:
                    bocalImage.GetComponent<Image>().overrideSprite = bocalLuciolesSprite;
                    bocalImage.SetActive(true);
                    break;

                case Item.ItemType.Torche:
                    torcheImage.SetActive(true);
                    break;

                case Item.ItemType.PiedDeBiche:
                    piedDeBicheImage.SetActive(true);
                    break;

                case Item.ItemType.Hache:
                    hacheImage.SetActive(true);
                    break;
            }
        }
    }

    public void RemoveItemHUD(Item.ItemType itemType)
    {
        if (currentItems.Contains(itemType))
        {
            currentItems.Remove(itemType);
            switch (itemType)
            {
                case Item.ItemType.Bocal:
                    bocalImage.SetActive(false);
                    break;

                case Item.ItemType.BocalLucioles:
                    bocalImage.SetActive(false);
                    break;

                case Item.ItemType.Torche:
                    torcheImage.SetActive(false);
                    break;

                case Item.ItemType.PiedDeBiche:
                    piedDeBicheImage.SetActive(false);
                    break;

                case Item.ItemType.Hache:
                    hacheImage.SetActive(false);
                    break;
            }
        }
    }

    public void UpdateHP(int hp)
    {
        hpSlider.value = hp;
    }

    public void DecreaseLive()
    {
        lives.Pop().gameObject.SetActive(false);
    }

	public void showDeathMessage(){
		StartCoroutine (Death());
	}

	IEnumerator Death(){
		yield return new WaitForSeconds(4.0f);
		DeathMessage.gameObject.SetActive (true);
	}
}
