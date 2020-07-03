using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneGoal1 : MonoBehaviour {
    float count = 0;
    public float limit = 3;
    Text goalText;
	// Use this for initialization
	void Start () {
        goalText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        count += Time.deltaTime;
        if (count > limit)
        {
            goalText.text = " ";
        }
	}
}
