using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private GameObject _obstaclePrefab;
    // Start is called before the first frame update
    void Start()
    {
        _obstaclePrefab = Resources.Load<LevelInfo>("Levels/LevelInfo " + PlayerPrefs.GetInt("LevelNumber", 1)).prefab;
        GameObject s1 = Instantiate(_obstaclePrefab, gameObject.transform.position, Quaternion.identity);
        s1.transform.SetParent(gameObject.transform, true);
    }
}
