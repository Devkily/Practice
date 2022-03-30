using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRN : MonoBehaviour
{
    [SerializeField] private PlayerRN _player;
    [SerializeField] private HeartRN _heartTemplate;

    private List<HeartRN> _hearts = new List<HeartRN>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }
    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }
    private void OnHealthChanged(int value)
    {
        if (_hearts.Count < value)
        {
            for (int i = 0; i < _hearts.Count; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value)
        {
            for (int i = 0; i < _hearts.Count; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
        
    }
    private void CreateHeart()
    {
        HeartRN newHeart = Instantiate(_heartTemplate, transform);
        _hearts.Add(newHeart.GetComponent<HeartRN>());
        newHeart.ToFill();
    }
    private void DestroyHeart(HeartRN heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }

}
