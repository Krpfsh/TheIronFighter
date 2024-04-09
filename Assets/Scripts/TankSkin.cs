using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TankSkin : MonoBehaviour
{
    [SerializeField] private ShopContent _contentItems;
    private void Awake()
    {
        foreach (var item in _contentItems.CharacterSkinItems.Cast<ShopItem>())
        {
            if (PlayerPrefs.GetString("Selected", "DefaultCar") == item.Name)
            {
                /// front rightleft back left right
                GameObject s1 = Instantiate(item.Model, gameObject.transform.position, Quaternion.identity);
                s1.transform.SetParent(gameObject.transform, true);
            }
        }
    }
}
