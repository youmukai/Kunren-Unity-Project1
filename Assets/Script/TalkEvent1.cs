using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkEvent1 : MonoBehaviour
{
    public string[] scenarios;
    int currentLine;
    [SerializeField] Text textbox;
    [SerializeField]private GameObject talkCanvas;
    [SerializeField] float lifeTime;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        talkCanvas.SetActive(!talkCanvas.activeSelf);
        StartIvent();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (talkCanvas.activeSelf)
        {
            timer += Time.deltaTime;
        }
        if (timer > lifeTime && talkCanvas.activeSelf)
        {
            talkCanvas.SetActive(false);
            timer = 0;
        }
    }

    public void MyPointerDownUI()
    {
        Debug.Log("押された");
        talkCanvas.SetActive(!talkCanvas.activeSelf);
        StartIvent();
    }
    void StartIvent()
    {
        textbox.text = scenarios[currentLine];
        int talkRn = Random.Range(currentLine, scenarios.Length);
        textbox.text = scenarios[talkRn];
    }
    void StartText(string[] scenarios)
    {

    }
}
