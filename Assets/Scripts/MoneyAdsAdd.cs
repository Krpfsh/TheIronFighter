using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using YG;
using System;

public class MoneyAdsAdd : MonoBehaviour
{
    //rewardManager
    //public static Action OnButtonSound;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { ExampleOpenRewardAd(2); });
    }
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }
    void ExampleOpenRewardAd(int id)
    {
        //OnButtonSound();
        YandexGame.RewVideoShow(id);
    }
    void Rewarded(int id)
    {
        switch (id)
        {
            case 2:
                
                AddMoney(1000);

                break;
            default:
                break;
        }
    }


    public void AddMoney(int moneyAdd)
    {
        DataManager.MoneyCount += moneyAdd;
        MoneyBehavior.UpdateText();
        DataManager.Save();
    }
}
