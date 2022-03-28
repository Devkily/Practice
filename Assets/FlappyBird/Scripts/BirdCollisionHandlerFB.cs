using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdFB))]
public class BirdCollisionHandlerFB : MonoBehaviour
{
    private BirdFB _bird;

    private void Start()
    {
        _bird = GetComponent<BirdFB>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ScoreZoneFB scoreZone))
        {
            ScoreManagerFB.scoreFB += 1;
        }
        else
        {
            _bird.Die();
        }
    }
}
