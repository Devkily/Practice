using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarSA : BarSA
{
    [SerializeField] private SpawnerSA _spawner;
    private void OnEnable()
    {
        _spawner.EnemyCountChenged += OnValueChanged;
        Slider.value = 0;
    }
    private void OnDisable()
    {
        _spawner.EnemyCountChenged -= OnValueChanged;
    }
}
