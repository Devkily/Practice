using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarSA : BarSA
{
    [SerializeField] private PlayerSA _player;
    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        Slider.value = 1;
    }
    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }
}
