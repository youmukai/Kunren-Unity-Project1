using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using TMPro;

public class TitleButton1 : MonoBehaviour
{
    [SerializeField] float speed;
     //private TextMeshProUGUI text;
    private Image image;
    private float time;
    private enum ObjType
    {
        TEXT,
        IMAGE
    };
    private ObjType thisObjType = ObjType.TEXT;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.GetComponent<Image>())
        {
            thisObjType = ObjType.IMAGE;
            image = this.gameObject.GetComponent<Image>();
        }
        /*else if (this.gameObject.GetComponent<TextMeshProUGUI>())
        {
            thisObjType = ObjType.TEXT;
            text = this.gameObject.GetComponent<TextMeshProUGUI>();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (thisObjType == ObjType.IMAGE)
        {
            image.color = GetAlphaColor(image.color);
        }
        /*else if (thisObjType == ObjType.TEXT)
        {
            text.color = GetAlphaColor(text.color);
        }*/
    }
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
    public void OnClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
