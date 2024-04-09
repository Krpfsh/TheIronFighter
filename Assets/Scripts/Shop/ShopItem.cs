using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShopItem : ScriptableObject
{
    //[field: SerializeField] public GameObject Model { get; private set; }
    [field: SerializeField] public Sprite modelImage { get; private set; }
    [field: SerializeField] public GameObject Model { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField, Range (0, 10000)] public int Price { get; private set; }
}
