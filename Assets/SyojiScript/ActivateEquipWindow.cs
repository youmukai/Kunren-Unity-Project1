using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEquipWindow : MonoBehaviour {
    void OnEnable()
    {
        transform.Find("EquipArea").GetComponent<CanvasGroup>().interactable = true;
        transform.Find("MenuArea").GetComponent<CanvasGroup>().interactable = true;
        transform.Find("EquipItemArea").GetComponent<CanvasGroup>().interactable = false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
