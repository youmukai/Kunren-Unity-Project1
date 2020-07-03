using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteButton1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    public void DeleteButton()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("GameScene");
    }
}
