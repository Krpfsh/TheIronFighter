using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //MenuManager Time scale выставлен на 1
    [Header("UI")]
    [SerializeField] private GameObject _skipLevelAds;
    [SerializeField] private GameObject _heartsObject;
    [Space]
    [SerializeField] private GameObject _levelWin;
    [SerializeField] private GameObject _levelLose;
    [Space]
    [SerializeField] private int _rewardOnWin;
    [SerializeField] private GameObject _player;
    private AudioManager _audioManager;
    private void OnEnable()
    {
        Tower.LevelWin += LevelWin;
        SkipLevelAds.LevelWin += LevelWin;
        HealthBehavior.LevelLose += LevelLose;
    }
    private void OnDisable()
    {
        Tower.LevelWin -= LevelWin;
        SkipLevelAds.LevelWin -= LevelWin;
        HealthBehavior.LevelLose -= LevelLose;
    }
    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }
    public void LevelWin()
    {
        _audioManager.Play("Win");
        CanvasOff();
        PlayerPrefs.SetInt("LevelNumber", PlayerPrefs.GetInt("LevelNumber", 1) + 1);
        PlayerPrefs.SetInt("LevelComplete", PlayerPrefs.GetInt("LevelComplete", 1) + 1);
        AddMoney(_rewardOnWin);
        _levelWin.gameObject.SetActive(true);
    }
    public void LevelLose()
    {
        CanvasOff();
        _levelLose.gameObject.SetActive(true);
    }

    private void CanvasOff()
    {
        Time.timeScale = 0f;
        _player.SetActive(false);
        _skipLevelAds.SetActive(false);
        _heartsObject.SetActive(false);
    }
    public void AddMoney(int moneyAdd)
    {
        DataManager.MoneyCount += moneyAdd;
        DataManager.Save();
    }
}
