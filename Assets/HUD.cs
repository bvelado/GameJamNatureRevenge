﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    List<Item.ItemType> currentItems;

    public GameObject bocalImage, torcheImage, piedDeBicheImage, hacheImage;
    public Sprite bocalSprite, bocalLuciolesSprite;

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
}