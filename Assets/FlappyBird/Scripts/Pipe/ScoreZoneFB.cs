using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZoneFB : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out BirdFB bird))
        {
            gameObject.SetActive(false);
        }
    }
}
