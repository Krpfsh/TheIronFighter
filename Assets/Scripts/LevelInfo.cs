using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "Gameplay/New LevelInfo")]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private int _towerLength;
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private LoopType _loopType;
    [SerializeField] private int _loopCount;

    public int towerLength => this._towerLength;
    public GameObject prefab => this._obstaclePrefab;
    public LoopType loopType => this._loopType;
}
