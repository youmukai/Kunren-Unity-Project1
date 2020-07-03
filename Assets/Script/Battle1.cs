using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void battle1()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void battle2()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void battle3()
    {
        SceneManager.LoadScene("Scene3");
    }
}
