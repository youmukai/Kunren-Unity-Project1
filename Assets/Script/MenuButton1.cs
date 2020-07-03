using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuButton1 : MonoBehaviour
{
    [SerializeField]private GameObject OptionCanvas;
    [SerializeField] private GameObject panel1;
    [SerializeField]private GameObject panel2;
    [SerializeField]private AudioMixer audioMixer;
    public Slider targetSlider;
    // Start is called before the first frame update
    void Start()
    {
        targetSlider.value = PlayerPrefs.GetFloat("Oto1", 0);
        masterVol(targetSlider);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            OptionCanvas.SetActive(!OptionCanvas.activeSelf);
        }
    }
    public void masterVol(Slider slider)
    {
        audioMixer.SetFloat("Oto1", slider.value);
    }
    public void SaveVolume(Slider slider)
    {
        PlayerPrefs.SetFloat("Oto1", slider.value);
        PlayerPrefs.Save();
    }
    public void OnClick()
    {
        panel2.SetActive(!panel2.activeSelf);
    }
    public void OnClick2()
    {
        OptionCanvas.SetActive(!OptionCanvas.activeSelf);
    }
    public void OnClick3()
    {
        panel1.SetActive(!panel1.activeSelf);
    }

    public void SetMaster(float Pre1AudioMixer)
    {
        audioMixer.SetFloat("MasterVol", Pre1AudioMixer);
    }
    public void SetBGM(float Pre1AudioMixer)
    {
        audioMixer.SetFloat("BGMVol", Pre1AudioMixer);// Exposed ParametersにBGMVolと設定する
    }
    public void SetSE(float Pre1AudioMixer)
    {
        audioMixer.SetFloat("SEVol", Pre1AudioMixer);
    }
}
