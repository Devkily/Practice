using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class PlayerSA : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<WeaponSA> _weapons;
    [SerializeField] private Transform _shootPoint;
    private WeaponSA _curentWeapon;
    private int _currentWaponNumber = 0;
    private int _currentHealth;
    private Animator _animator;
    public int Money { get; private set; }
    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    private void Start()
    {
        ChangeWeapon(_weapons[_currentWaponNumber]);
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _curentWeapon.Shoot(_shootPoint);
        }
    }
    private void OnEnemyDied(int reward)
    {
        Money += reward;
    }
    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth,_health);
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }
    public void BuyWeapon(WeaponSA weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        _weapons.Add(weapon);
    }
    public void NextWeapon()
    {
        if (_currentWaponNumber == _weapons.Count - 1)
        {
            _currentWaponNumber = 0;
        }
        else
        {
            _currentWaponNumber++;
        }
        ChangeWeapon(_weapons[_currentWaponNumber]);
    }
    public void PreviousWeapon()
    {
        if (_currentWaponNumber == 0)
        {
            _currentWaponNumber = _weapons.Count - 1;
        }
        else
        {
            _currentWaponNumber--;
        }
        ChangeWeapon(_weapons[_currentWaponNumber]);
    }
    private void ChangeWeapon(WeaponSA weapon)
    {
        _curentWeapon = weapon;
    }
}
