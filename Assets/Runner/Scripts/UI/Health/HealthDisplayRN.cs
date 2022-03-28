using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HealthDisplayRN : MonoBehaviour
{
    [SerializeField] private PlayerRN _player;
    [SerializeField] private TMP_Text _healthUI;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }
    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _healthUI.text = health.ToString();
    }
}
