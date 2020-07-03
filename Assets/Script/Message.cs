using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Message : MonoBehaviour {
    private Text messageText;
    [SerializeField]
    [TextArea(1, 20)]
    private string allMessage = "ゴールしました\n" +
        "これでゲームクリアです\n" +
        "<>お疲れ様でした";
    [SerializeField] private string splitString = "<>";
    private string[] splitMessage;
    private int messageNum;
    [SerializeField] private float textSpeed = 0.05f;
    private float elapsedTime = 0f;
    private int nowTextNum = 0;
    private Image clickIcon;
    [SerializeField] private float clickFlashTime = 0.2f;
    private bool isOneMessage = false;
    private bool isEndMessage = false;
    private Transform messageUI;
	// Use this for initialization
	void Start () {
        clickIcon = transform.Find("MessageUI/Image").GetComponent<Image>();
        clickIcon.enabled = false;
        messageUI = transform.Find("MessageUI");
        messageText = messageUI.GetComponentInChildren<Text>();
        messageText.text = "";
        SetMessage(allMessage);
    }
	
	// Update is called once per frame
	void Update () {
        if (isEndMessage || allMessage == null)
        {
            return;
        }
        if (!isOneMessage)
        {
            if (elapsedTime >= textSpeed)
            {
                messageText.text += splitMessage[messageNum][nowTextNum];
                nowTextNum++;
                elapsedTime = 0f;
                if (nowTextNum >= splitMessage[messageNum].Length)
                {
                    isOneMessage = true;
                }
            }
            elapsedTime += Time.deltaTime;
            if (Input.GetMouseButtonDown(0))
            {
                messageText.text += splitMessage[messageNum].Substring(nowTextNum);
                isOneMessage = true;
            }
        }
        else
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= clickFlashTime)
            {
                clickIcon.enabled = !clickIcon.enabled;
                elapsedTime = 0f;
            }
            if (Input.GetMouseButtonDown(0))
            {
                nowTextNum = 0;
                messageNum++;
                messageText.text = "";
                clickIcon.enabled = false;
                elapsedTime = 0f;
                isOneMessage = false;
                if (messageNum >= splitMessage.Length)
                {
                    isEndMessage = true;
                    transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
    void SetMessage(string message)
    {
        this.allMessage = message;
        splitMessage = Regex.Split(allMessage, @"\s*" + splitString + @"\s*", 
            RegexOptions.IgnorePatternWhitespace);
        nowTextNum = 0;
        messageNum = 0;
        messageText.text = "";
        isOneMessage = false;
        isEndMessage = false;
    }
    public void SetMessagePanel(string message)
    {
        SetMessage(message);transform.GetChild(0).gameObject.SetActive(true);
    }
}
