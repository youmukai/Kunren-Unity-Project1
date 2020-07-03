using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateEquipItemButton : MonoBehaviour {
    private StatusWindowStatus statusWindowStatus;
    private ItemController itemController;
    private StatusWindowItemDataBase statusWindowItemDataBase;
    public GameObject equipButtonPrefab;
    private GameObject[] item;
    void OnEnable()
    {
        GetComponent<CanvasGroup>().interactable = false;
        statusWindowStatus = Camera.main.GetComponent<StatusWindowStatus>();
        itemController = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemController>();
        statusWindowItemDataBase = Camera.main.GetComponent<StatusWindowItemDataBase>();
        item = new GameObject[statusWindowItemDataBase.GetItemTotal()];
        for (var i = 0; i < statusWindowItemDataBase.GetItemTotal(); i++)
        {
            if(statusWindowItemDataBase.GetItemData()[i].GetItemType()==
                StatusWindowItemDataBase.Item.UseItem || !itemController.GetItemFlag(i) && !statusWindowStatus.GetItemFlag(i))
            {
                continue;
            }
            item[i] = GameObject.Instantiate(equipButtonPrefab) as GameObject;
            item[i].name = "EquipItem" + i;
            item[i].transform.SetParent(transform,false);
            item[i].transform.GetChild(0).GetComponent<Image>().sprite = 
                statusWindowItemDataBase.GetItemData()[i].GetItemSprite();
            item[i].transform.GetChild(0).GetComponent<Button>().interactable = true;
            item[i].transform.GetChild(0).GetComponent<EquipItemButton>().
                SetStatusWindowItemData(statusWindowItemDataBase.GetItemData()[i]);
        }
    }
    void OnDisable()
    {
        for (var i = 0; i < statusWindowItemDataBase.GetItemTotal(); i++)
        {
            Destroy(item[i]);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
