using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundSwitcherButton : MonoBehaviour
{
    public Sprite audioOn;
    public Sprite audioOff;

    [SerializeField] private GameObject onButton;
    [SerializeField] private GameObject offButton;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("SoundIsOn", 1) == 1)
        {
            onButton.GetComponent<Image>().sprite = audioOn;
            offButton.GetComponent<Image>().sprite = audioOff;
            AudioListener.volume = 1;
            AudioListener.pause = false;
        }
        else
        {
            onButton.GetComponent<Image>().sprite = audioOff;
            offButton.GetComponent<Image>().sprite = audioOn;
            AudioListener.volume = 0;
            AudioListener.pause = true;
        }
    }
    public void OnButtonClick()
    {
        if (PlayerPrefs.GetInt("SoundIsOn", 1) == 1)
        {
            PlayerPrefs.SetInt("SoundIsOn", 0);
            onButton.GetComponent<Image>().sprite = audioOn;
            offButton.GetComponent<Image>().sprite = audioOff;
            AudioListener.volume = 0;
            AudioListener.pause = true;
        }
    }
    public void OffButtonClick()
    {
        if (PlayerPrefs.GetInt("SoundIsOn", 1) == 0)
        {
            PlayerPrefs.SetInt("SoundIsOn", 1);
            onButton.GetComponent<Image>().sprite = audioOff;
            offButton.GetComponent<Image>().sprite = audioOn;
            AudioListener.volume = 1;
            AudioListener.pause = false;
        }
    }
}
