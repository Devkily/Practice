using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRN : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerRN player))
        {
            player.ApplyDamage(_damage);
        }
        else
        {
            ScoreManagerRN.scoreRN += 10;
        }
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
