using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySA : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    private PlayerSA _target;
    public int Reward => _reward;
    public PlayerSA Target => _target;
    public event UnityAction<EnemySA> EnemyDied;

    public void Init(PlayerSA target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            EnemyDied?.Invoke(this);
            Destroy(gameObject);
        }
    }
    
}
