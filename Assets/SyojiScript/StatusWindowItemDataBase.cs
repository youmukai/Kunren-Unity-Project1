using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusWindowItemDataBase : MonoBehaviour {
    public enum Item
    {
        Sword,
        HandGun,
        ShotGun,
        UseItem
    };
    private StatusWindowItemData[] itemLists = new StatusWindowItemData[4];
    void Awake()
    {
        itemLists[0] = new StatusWindowItemData(Resources.Load("coins", typeof(Sprite))
            as Sprite, "懐中電灯", Item.Sword, "あれば便利な辺りを照らすライト");
        itemLists[1] = new StatusWindowItemData(Resources.Load("axe", typeof(Sprite))
            as Sprite, "ナイフ", Item.Sword, "切れ味の鋭いナイフ");
        itemLists[2] = new StatusWindowItemData(Resources.Load("sword", typeof(Sprite))
            as Sprite, "ブロードソード", Item.Sword, "大剣");
        itemLists[3] = new StatusWindowItemData(Resources.Load("gem", typeof(Sprite))
            as Sprite, "ハンドガン", Item.HandGun, "威力抜群ハンドガン");
    }
    public StatusWindowItemData[] GetItemData()
    {
        return itemLists;
    }
    public int GetItemTotal()
    {
        return itemLists.Length;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
