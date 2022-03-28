using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRN : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _gameOverUI;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;
    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }
    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
        if (_health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        _gameOverUI.SetActive(true);
        Died?.Invoke();
    }
}
