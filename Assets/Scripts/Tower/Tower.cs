using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<Block> _blocks;

    public event UnityAction<int> SizeUpdated;
    public static event UnityAction LevelWin;
    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _blocks = _towerBuilder.Build();

        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }
        SizeUpdated?.Invoke(_blocks.Count);
    }
    private void OnBulletHit(Block hitedBlock)
    {
        hitedBlock.BulletHit -= OnBulletHit;
        _blocks.Remove(hitedBlock);

        foreach(var block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x,block.transform.position.y - block.transform.localScale.y, block.transform.position.z);
        }
        SizeUpdated?.Invoke(_blocks.Count);
        if(_blocks.Count <= 0)
        {
            LevelWin?.Invoke();
        }
    }
    
}
