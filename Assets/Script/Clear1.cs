using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear1 : MonoBehaviour
{
    [SerializeField] private GameObject panel2;
    [SerializeField] private GameObject stage2;
    [SerializeField] private GameObject mikuri1;
    [SerializeField] private GameObject mikuri2;
    [SerializeField] private GameObject mikuri3;
    [SerializeField] private GameObject stage3;
    private bool ste1 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (panel2.activeSelf)
        {
            ste1 = true;
            if (PlayerPrefs.GetInt("stage1Clear", 0) == 1)
            {
                stage2.SetActive(true);
                mikuri2.SetActive(true);
                mikuri1.SetActive(false);
                ste1 = false;
            }
            else
            {
                stage2.SetActive(false);
                mikuri2.SetActive(false);
            }
            if (PlayerPrefs.GetInt("stage2Clear", 0) == 2)
            {
                stage3.SetActive(true);
                mikuri3.SetActive(true);
                mikuri2.SetActive(false);
            }
            else
            {
                stage3.SetActive(false);
                mikuri3.SetActive(false);
            }
        }
    }
    public void OnClick()
    {
        panel2.SetActive(!panel2.activeSelf);
        
    }
}
