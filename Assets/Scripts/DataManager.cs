using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public static int LevelNumber = PlayerPrefs.GetInt("LevelNumber",1);
    public static int LevelComplete = PlayerPrefs.GetInt("LevelComplete",1);
    public static int MoneyCount = PlayerPrefs.GetInt("Money",0);

    public static void Save()
    {
        PlayerPrefs.SetInt("Money", MoneyCount);
    }
}
