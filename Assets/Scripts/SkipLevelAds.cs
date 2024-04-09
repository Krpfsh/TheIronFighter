using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YG;

public class SkipLevelAds : MonoBehaviour
{
    public static event UnityAction LevelWin;
    private Button _button;
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(delegate { ExampleOpenRewardAd(1); });
    }
    void Rewarded(int id)
    {
        if(id == 1)
        {
            LevelWin?.Invoke();
        }
    }
    private void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }
}
