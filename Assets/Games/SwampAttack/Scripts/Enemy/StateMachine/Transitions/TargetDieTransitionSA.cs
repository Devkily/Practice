using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieTransitionSA : TransitionSA
{
    private void Update()
    {
        if (Target == null)
        {
            NeedTransit = true;
        }
    }
}
