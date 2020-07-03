using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEquip : MonoBehaviour {
    [SerializeField] private GameObject[] weapons;
    //private int equipment;

    //public Camera camera_object;
    //private RaycastHit hit;
    //private StatusWindowItemData statusWindowItemData;
    //private StatusWindowItemDataBase statusWindowItemDataBase;
    //private EquipItemButton equip;
    //string objectName;
    //private ItemController itemController;

    //private ProcessCharaAnimEvent processCharaAnimEvent;
    //private CharacterScript characterScript;
    // Use this for initialization
    void Start () {
        //itemController = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemController>();
        //statusWindowItemDataBase = Camera.main.GetComponent<StatusWindowItemDataBase>();
        //equipment = 0;
        //weapons[equipment].SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetKeyDown("1"))
        {
            ChangeWeapon();
        }*/
        /*if (Input.GetMouseButtonDown(0)){
            Ray ray = camera_object.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                objectName = hit.collider.gameObject.name;
                Debug.Log(objectName);
            }
        }*/
    }
    public void ChangeWeapon(string objname)
    {
        /*equipment++;
        if (equipment >= weapons.Length)
        {
            equipment = 0;
        }*/
        for (var i = 0; i < weapons.Length; i++)//statusWindowItemData.GetItemName()
        {
            if (weapons[i].name == objname)//statusWindowItemDataBase.GetItemData()[i].GetItemName()
            {
                Debug.Log(weapons[i].name);
                weapons[i].SetActive(true);
                //processCharaAnimEvent.SetCollider(weapons[i].GetComponent<Collider>());
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }
}
