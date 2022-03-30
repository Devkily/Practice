using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemySA))]
public class EnemyStateMachineSA : MonoBehaviour
{
    [SerializeField] private StateSA _firstState;

    private PlayerSA _target;
    private StateSA _currentState;

    public StateSA Current => _currentState;

    private void Start()
    {
        _target = GetComponent<EnemySA>().Target;
        Reset(_firstState);
    }
    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }
        var nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            Transit(nextState);
        }
    }
    private void Reset(StateSA startState)
    {
        _currentState = startState;
        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }
    private void Transit(StateSA nextstate)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = nextstate;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }
}
