using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBehavior : MonoBehaviour
{
    public static Action UpdateText;

    private void OnEnable()
    {
        UpdateText += MoneyTextUpdate;
    }
    private void OnDisable()
    {
        UpdateText -= MoneyTextUpdate;
    }
    private void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = DataManager.MoneyCount.ToString();
    }
    public void MoneyTextUpdate()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = DataManager.MoneyCount.ToString();
    }

}
