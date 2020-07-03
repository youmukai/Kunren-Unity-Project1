using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour {
    [SerializeField] private string informationString;
    [SerializeField] private Text informationText;
    private CanvasGroup canvasGroup;
    private GameObject returnButton;
	// Use this for initialization
	void Start () {
        canvasGroup = GetComponentInParent<CanvasGroup>();
        returnButton = transform.parent.Find("Exit").gameObject;
	}
    void OnEnable()
    {
        GetComponent<Button>().interactable = true;
    }
    public void OnSelsected()
    {
        if (canvasGroup == null || canvasGroup.interactable)
        {
            if (EventSystem.current.currentSelectedGameObject != gameObject && !EventSystem.current.alreadySelecting)
            {
                EventSystem.current.SetSelectedGameObject(gameObject);
            }
            informationText.text = informationString;
        }
    }
    public void OnDeselected()
    {
        informationText.text = "";
    }
    public void DisableWindow()
    {
        if (canvasGroup == null || canvasGroup.interactable)
        {
            transform.root.gameObject.SetActive(false);
        }
    }
    public void WindowOnOff(GameObject window)
    {
        if (canvasGroup == null || canvasGroup.interactable)
        {
            Camera.main.GetComponent<OperationStatusWindow>().ChangeWindow(window);
        }
    }
    public void SelectRerurnButton()
    {
        EventSystem.current.SetSelectedGameObject(returnButton);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
