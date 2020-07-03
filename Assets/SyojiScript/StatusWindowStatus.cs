using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusWindowStatus : MonoBehaviour {
    [SerializeField] private bool[] itemFlags = new bool[6];
    private StatusWindowItemDataBase statusWindowItemDataBase;
	// Use this for initialization
	void Start () {
        statusWindowItemDataBase = GetComponent<StatusWindowItemDataBase>();
        SetItemData("懐中電灯");
        SetItemData("ハンドガン");
	}
    public bool GetItemFlag(int num)
    {
        return itemFlags[num];
    }
    public void SetItemData(string name)
    {
        var itemDatas = statusWindowItemDataBase.GetItemData();
        for(int i = 0; i < itemDatas.Length; i++)
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
