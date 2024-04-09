using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopPanel : MonoBehaviour
{
    private List<ShopItemView> _shopItems = new List<ShopItemView>();

    [SerializeField] private Transform _itemParent;
    [SerializeField] private ShopItemViewFactory _shopItemViewFactory;

    //public static Action OnBuySkin;
    private void Start()
    {
        PlayerPrefs.SetString("DefaultCar", "true");
        foreach (var item in _shopItems)
        {
            //���������� ��� ����� � ���������, � ������� true
            if (PlayerPrefs.GetString($"{item.Name}") == "true"){
                item.Unlock();
            }
            //���������� ��� ����� � �������� 
            if(PlayerPrefs.GetString("Selected", "DefaultCar") == item.Name)
            {
                item.Select();
                item.Highlight();
                item.Unlock();
            }
        }
        
    }
    public void Show(IEnumerable<ShopItem> items)
    {
        Clear();
        foreach (ShopItem item in items)
        {
            ShopItemView spawnedItem = _shopItemViewFactory.Get(item, _itemParent);

            spawnedItem.Click += OnItemViewClick;

            spawnedItem.Unselect();
            spawnedItem.UnHighlight();

            //�������� ���������� ����� � ��

            _shopItems.Add(spawnedItem);
        }
    }

    private void OnItemViewClick(ShopItemView view)
    {
        //�������� ������ �� � ��� ����
        if(PlayerPrefs.GetString($"{view.Name}") == "true")
        {
            //������
            PlayerPrefs.SetString("Selected", view.Name);
            foreach (var item in _shopItems)
            {
                item.Unselect();
                item.UnHighlight();
            }
            view.Select();
            view.Highlight();
            view.Unlock();
        }
        else
        {
            //�� ������ 
            //������� �� ��� �����
            if (view.Price <= DataManager.MoneyCount)
            {
                DataManager.MoneyCount -= view.Price;
                DataManager.Save();
                MoneyBehavior.UpdateText();
                PlayerPrefs.SetString($"{view.Name}", "true");
                PlayerPrefs.SetString("Selected", view.Name);
                foreach (var item in _shopItems)
                {
                    item.Unselect();
                    item.UnHighlight();
                }
                // ���� OnBuySkin();
                view.Select();
                view.Highlight();
                view.Unlock();
            }
            else
            {
                //������������ �����
            }
        }
        
    }

    private void Clear()
    {
        foreach(ShopItemView item in _shopItems)
        {
            item.Click -= OnItemViewClick;
            Destroy(item.gameObject);
        }
        _shopItems.Clear();
    }
}
