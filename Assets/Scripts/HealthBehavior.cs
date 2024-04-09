using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBehavior : MonoBehaviour
{
    [SerializeField] Image[] _heartsImages;


    [Space]
    [SerializeField] Sprite _hearthOn;
    [SerializeField] Sprite _hearthOff;

    public static event UnityAction LevelLose;
    private int _lives;
    private void OnEnable()
    {
        Bullet.OnPlayerHit += TakeDamage;
    }
    private void OnDisable()
    {
        Bullet.OnPlayerHit -= TakeDamage;
    }
    private void Start()
    {
        _lives = 3;
        UpdateHealthImages();
    }
    public void TakeDamage()
    {
        _lives--;
        UpdateHealthImages();
        if(_lives == 0)
        {
            LevelLose?.Invoke();
        }
    }

    private void UpdateHealthImages()
    {
        if(_lives <= 3) {
            for (int i = 0; i < _heartsImages.Length; i++)
            {
                _heartsImages[i].sprite = _hearthOff;
            }
        }
        for (int i = 0; i < _lives; i++)
        {
            _heartsImages[i].sprite = _hearthOn;
        }
    }
}
