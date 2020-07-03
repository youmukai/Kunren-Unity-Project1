using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipItemButton : MonoBehaviour {
    private StatusWindowItemDataBase statusWindowItemDataBase;
    private StatusWindowItemData[] itemLists;
    private Image imageComp;

    private StatusWindowItemData statusWindowItemData;
    private Transform equipArea;
    private Transform menuArea;
    private Transform equipItemArea;
    private Text informationText;
    private SelectedEquipButton selectedEquipButton;

    //private GameObject weaponObj;
    //bool check = false;
    //[SerializeField] private GameObject[] weapons;
    private GameObject game3d7Pre;
    private ChangeEquip changeEquip;
    // Use this for initialization
    void Start()
    {
        equipArea = transform.parent.parent.parent.Find("EquipArea");
        menuArea = transform.parent.parent.parent.Find("MenuArea");
        equipItemArea = transform.parent.parent.parent.Find("EquipItemArea");
        informationText = transform.parent.parent.parent.Find("Information/Text").
            GetComponent<Text>();
        selectedEquipButton = equipArea.GetComponent<SelectedEquipButton>();

        game3d7Pre = GameObject.FindGameObjectWithTag("Player");
        changeEquip = game3d7Pre.GetComponentInChildren<ChangeEquip>();
        imageComp = GetComponent<Image>();
        statusWindowItemDataBase = Camera.main.GetComponent<StatusWindowItemDataBase>();
    }
    public void OnClick()
    {
        if (GetComponentInParent<CanvasGroup>().interactable)
        {
            EventSystem.current.SetSelectedGameObject(null);
            equipArea.GetComponent<CanvasGroup>().interactable = true;
            menuArea.GetComponent<CanvasGroup>().interactable = true;
            equipItemArea.GetComponent<CanvasGroup>().interactable = false;
            var equipButton = equipArea.transform.GetChild(selectedEquipButton.
                GetSelectedEquipButton()).GetComponentInChildren<EquipButton>();
            equipButton.SetStatusWindowItemData(statusWindowItemData);
            EventSystem.current.SetSelectedGameObject(equipArea.GetChild(
                selectedEquipButton.GetSelectedEquipButton()).GetChild(0).gameObject);

            /*if (!check)
            {
                weaponObj.SetActive(false);
                check = true;
            }else if (check)
            {

                weaponObj.SetActive(true);
                check = false;
            }*/
            int selectedNum = 5;
            switch (imageComp.sprite.name)
            {
                case "coins":
                    selectedNum = 0;
                    break;
                case "axe":
                    selectedNum = 1;
                    break;
                case "sword":
                    selectedNum = 2;
                    break;
                case "gem":
                    selectedNum = 3;
                    break;
            }
            itemLists = statusWindowItemDataBase.GetItemData();
            changeEquip.ChangeWeapon(itemLists[selectedNum].GetItemName());
        }
    }
    public void OnSelected()
    {
        if (GetComponent<Button>().interactable)
        {
            if (GetComponent<Image>().sprite != null)
            {
                informationText.text = statusWindowItemData.GetItemInformation();
            }
            transform.parent.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
    public void OnDeselected()
    {
        informationText.text = "";
    }
    public void SetStatusWindowItemData(StatusWindowItemData itemData)
    {
        statusWindowItemData = itemData;
    }
    /*public void ChangeWeapon()
    {
        var equipButton = equipArea.transform.GetChild(selectedEquipButton.
                GetSelectedEquipButton()).GetComponentInChildren<EquipButton>();
        for (var i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].name == statusWindowItemData.GetItemName())
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
    }*/

    // Update is called once per frame
    void Update () {
		
	}
}
