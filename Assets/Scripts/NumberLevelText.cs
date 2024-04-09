using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class NumberLevelText : MonoBehaviour
{
    private TextMeshProUGUI _numberLevel;

    private void Awake()
    {
        _numberLevel = GetComponent<TextMeshProUGUI>();
        _numberLevel.text = PlayerPrefs.GetInt("LevelComplete", 1).ToString();
    }
}
