using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILightBlockState : AIStateController
{
    public override void EnterState(AIController ai)
    {
        // Dont attack if hasn't been enough time since last attack
        // This prevents edge case of ai being pushed outside of attack range and then immediately returns inside attack range and attacking milliseconds after being pushed out
        if (Time.time - ai.timeSinceLastAttackAction > ai.minAttackWaitTime && ai.target != null)
        {
            ai.timeSinceLastAttackAction = Time.time;
        }
    }

    public override void UpdateState(AIController ai)
    {
    }

    public override void FixedUpdateState(AIController ai)
    {

    }
}
