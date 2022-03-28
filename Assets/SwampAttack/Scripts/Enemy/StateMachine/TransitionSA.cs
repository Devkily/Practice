using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransitionSA : MonoBehaviour
{
    [SerializeField] private StateSA _targetState;

    protected PlayerSA Target { get; private set; }

    public StateSA TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    public void Init(PlayerSA target)
    {
        Target = target;
    }
    private void OnEnable()
    {
        NeedTransit = false;
    }

}
