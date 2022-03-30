using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackStateSA : StateSA
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    private float _lastAttackTime;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }
        _lastAttackTime -= Time.deltaTime;
    }
    private void Attack(PlayerSA target)
    {
        _animator.Play("Enemy_attack");
        target.ApplyDamage(_damage);
    }    
}
