using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationStateSA : StateSA
{
    private Animator _amimator;

    private void Awake()
    {
        _amimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _amimator.Play("Enemy_celebration");
    }
    private void OnDisable()
    {
        _amimator.StopPlayback();
    }
}
