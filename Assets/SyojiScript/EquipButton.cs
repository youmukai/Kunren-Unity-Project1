using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour {
    private StatusWindowItemData statusWindowItemData;
    private Transform equipArea;
    private Transform menuArea;
    private Transform equipItemArea;
    private Text informationText;
    private SelectedEquipButton selectedEquipButton;
    private CanvasGroup canvasGroup;
    [SerializeField] private int equipNum;
    private GameObject returnButton;
	// Use this for initialization
	void Start () {
        equipArea = transform.parent.parent;
        menuArea = transform.parent.parent.parent.Find("MenuArea");
        equipItemArea = transform.parent.parent.parent.Find("EquipItemArea");
        informationText = transform.parent.parent.parent.Find("Information/Text").
            GetComponent<Text>();
        selectedEquipButton = GetComponentInParent<SelectedEquipButton>();
        canvasGroup = equipArea.GetComponent<CanvasGroup>();
        returnButton = menuArea.Find("Exit").gameObject;
	}
	public void OnClick()
    {
        if (canvasGroup.interactable)
        {
            transform.parent.GetComponent<Image>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
            EventSystem.current.SetSelectedGameObject(null);
            equipArea.GetComponent<CanvasGroup>().interactable = false;
            menuArea.GetComponent<CanvasGroup>().interactable = false;
            equipItemArea.GetComponent<CanvasGroup>().interactable = true;
            selectedEquipButton.SetSelectedEquipButton(equipNum);
            EventSystem.current.SetSelectedGameObject(equipItemArea.GetChild(0).GetChild(0).gameObject);
        }
    }
    public void OnSelected()
    {
        if (canvasGroup.interactable)
        {
            if (statusWindowItemData != null)
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
        GetComponent<Image>().sprite = statusWindowItemData.GetItemSprite();
        transform.parent.GetComponent<Image>().color = new Color(1f, 1f, 1f, 100f / 255f);
    }
    void OnEnable()
    {
        GetComponent<Button>().interactable = true;
    }
    public void OnDisable()
    {
        transform.parent.GetComponent<Image>().color = new Color(1f, 1f, 1f, 100f / 255f);
    }
    public void SelectReturnButton()
    {
        EventSystem.current.SetSelectedGameObject(returnButton);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
