using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon1 : MonoBehaviour {
    private StatusWindowItemData statusWindowItemData;
    public EquipButton equipButton;
	// Use this for initialization
	void Start () {
        equipButton = GetComponent<EquipButton>();
        equipButton.SetStatusWindowItemData(statusWindowItemData);
	}

    // Update is called once per frame
    void Update () {
		
	}
}
