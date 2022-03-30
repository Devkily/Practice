using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSA : MonoBehaviour
{
    [SerializeField] private List<TransitionSA> _transitions;

    protected PlayerSA Target { get; set; }

    public void Enter(PlayerSA target)
    {
        if (enabled == false)
        {
            Target = target;
            enabled = true;
            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }
    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }
            enabled = false;
        }
    }
    public StateSA GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }
        return null;
    }
}
