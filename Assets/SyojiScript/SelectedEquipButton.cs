using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedEquipButton : MonoBehaviour {
    public int selectedEquipButton;
	// Use this for initialization
	void Start () {
        selectedEquipButton = -1;
	}
    public void SetSelectedEquipButton(int select)
    {
        selectedEquipButton = select;
    }
    public int GetSelectedEquipButton()
    {
        return selectedEquipButton;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
