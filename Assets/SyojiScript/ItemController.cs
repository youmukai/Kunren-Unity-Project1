using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {
    [SerializeField] private bool[] itemFlags = new bool[6];
    private StatusWindowItemDataBase statusWindowItemDataBase;

    // Use this for initialization
    void Start () {
        statusWindowItemDataBase = Camera.main.GetComponent<StatusWindowItemDataBase>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "NaihuItem")
        {
            SetItemData("ナイフ");
        }else if(col.gameObject.name == "burodoItem")
        {
            SetItemData("ブロードソード");
        }
        if (col.gameObject.tag == "Item")
        {
            Debug.Log("itemOk");
            Destroy(col.gameObject);
        }
    }
    public bool GetItemFlag(int num)
    {
        return itemFlags[num];
    }
    public void SetItemData(string name)
    {
        var itemDatas = statusWindowItemDataBase.GetItemData();
        for (int i = 0; i < itemDatas.Length; i++)
        {
            if (itemDatas[i].GetItemName() == name)
            {
                itemFlags[i] = true;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
