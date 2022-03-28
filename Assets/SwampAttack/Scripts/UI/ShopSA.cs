using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSA : MonoBehaviour
{
    [SerializeField] private List<WeaponSA> _weapons;
    [SerializeField] private PlayerSA _player;
    [SerializeField] private WeaponViewSA _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(WeaponSA weapon)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(weapon);
    }
    private void OnSellButtonClick(WeaponSA weapon, WeaponViewSA view)
    {
        TrySellWeapon(weapon, view);
    }
    private void TrySellWeapon(WeaponSA weapon, WeaponViewSA view)
    {
        if (weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            view.SellButtonClick -= OnSellButtonClick;
        }
    }
}
