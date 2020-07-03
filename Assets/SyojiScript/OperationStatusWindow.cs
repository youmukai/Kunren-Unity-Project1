using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OperationStatusWindow : MonoBehaviour {
    [SerializeField] private GameObject propertyWindow;
    [SerializeField] private GameObject[] windowLists;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Start"))
        {
            propertyWindow.SetActive(!propertyWindow.activeSelf);
            ChangeWindow(windowLists[0]);
        }
	}
    public void ChangeWindow(GameObject window)
    {
        foreach(var item in windowLists)
        {
            if (item == window)
            {
                item.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
            }
            else
            {
                item.SetActive(false);
            }
            EventSystem.current.SetSelectedGameObject(window.transform.Find("MenuArea").
                GetChild(0).gameObject);
        }
    }
}
