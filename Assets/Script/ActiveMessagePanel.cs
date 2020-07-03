using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMessagePanel : MonoBehaviour {
    [SerializeField] private Message messageScript;
    private string message = "もうゲームクリアだよ<>"
                           + "お疲れ様";
    bool fla = false;
    public GameObject sain;
	// Use this for initialization
	void Start () {
        sain.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2")&& fla==true)
        {
            Debug.Log("kaiwa");
            messageScript.SetMessagePanel(message);
        }
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fla = true;
            sain.transform.position = gameObject.transform.position + new Vector3(1.67f, -1.25f, -1.14f);
            sain.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fla = false;
            sain.SetActive(false);
        }
    }
}
