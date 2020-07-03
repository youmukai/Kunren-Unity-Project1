using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusWindowItemData : object {
    private Sprite itemSprite;
    private string itemName;
    private StatusWindowItemDataBase.Item itemType;
    private string itemInformation;

    public StatusWindowItemData(Sprite image, string itemName,
        StatusWindowItemDataBase.Item itemType, string information)
    {
        this.itemSprite = image;
        this.itemName = itemName;
        this.itemType = itemType;
        this.itemInformation = information;
    }
    public Sprite GetItemSprite()
    {
        return itemSprite;
    }
    public string GetItemName()
    {
        return itemName;
    }
    public StatusWindowItemDataBase.Item GetItemType()
    {
        return itemType;
    }
    public string GetItemInformation()
    {
        return itemInformation;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
