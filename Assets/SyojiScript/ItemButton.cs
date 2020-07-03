using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {
    private Text informationText;
    private StatusWindowItemDataBase itemDataBase;
    private int itemNum;
	// Use this for initialization
	void Start () {
        itemDataBase = Camera.main.GetComponent<StatusWindowItemDataBase>();
        informationText = transform.parent.parent.parent.Find("Information/Text").
            GetComponent<Text>();
	}
	
    public void OnSelected()
    {
        informationText.text = itemDataBase.GetItemData()[itemNum].GetItemInformation();
    }
    public void OnDeselected()
    {
        informationText.text = "";
    }
    public void SetItemNum(int number)
    {
        itemNum = number;
    }
    public int GetItemNum()
    {
        return itemNum;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
