using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateItemButon : MonoBehaviour {
    private StatusWindowStatus statusWindowStatus;
    private ItemController itemController;
    private StatusWindowItemDataBase statusWindowItemDataBase;
    public GameObject itemPrefab;
    private GameObject[] item;
    void OnEnable()
    {
        statusWindowStatus = Camera.main.GetComponent<StatusWindowStatus>();
        itemController = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemController>(); 
        statusWindowItemDataBase = Camera.main.GetComponent<StatusWindowItemDataBase>();
        item = new GameObject[statusWindowItemDataBase.GetItemTotal()];
        for(var i = 0; i < statusWindowItemDataBase.GetItemTotal(); i++)
        {
            item[i] = GameObject.Instantiate(itemPrefab) as GameObject;
            item[i].name = "Item" + i;
            item[i].transform.SetParent(transform,false);
            if (statusWindowStatus.GetItemFlag(i))
            {
                item[i].transform.GetChild(0).GetComponent<Image>().sprite = 
                    statusWindowItemDataBase.GetItemData()[i].GetItemSprite();
            }else if (itemController.GetItemFlag(i))
            {
                item[i].transform.GetChild(0).GetComponent<Image>().sprite =
                    statusWindowItemDataBase.GetItemData()[i].GetItemSprite();
            }
            else
            {
                item[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                item[i].transform.GetChild(0).GetComponent<Button>().interactable = false;
            }
            item[i].transform.GetChild(0).GetComponent<ItemButton>().SetItemNum(i);
        }
    }
    void OnDisable()
    {
        for(var i = 0; i < statusWindowItemDataBase.GetItemTotal(); i++)
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
