using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIStateController
{
    public override void EnterState(AIController ai)
    {
        ai.AcquireTarget();
    }

    public override void UpdateState(AIController ai)
    {

    }

    public override void FixedUpdateState(AIController ai)
    {

    }
}
