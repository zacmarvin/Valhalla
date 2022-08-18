using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHorsebackAttackState : AIStateController
{

    bool runaway = false;

    Vector3 direction = Vector3.zero;

    public override void EnterState(AIController ai)
    {
        // Dont attack if hasn't been enough time since last attack
        // This prevents edge case of ai being pushed outside of attack range and then immediately returns inside attack range and attacking milliseconds after being pushed out
        if (Time.time - ai.timeSinceLastAttackAction > ai.minAttackWaitTime && ai.target != null)
        {
            ai.timeSinceLastAttackAction = Time.time;

            if (ai.targetAIController != null)
            {
                ai.targetAIController.TakeHit(ai.horseAttackDamage);
            }
            runaway = true;
            direction = ai.targetTransform.position - ai.transform.position;
            direction.Normalize();
        }
    }

    public override void UpdateState(AIController ai)
    {


    }

    public override void FixedUpdateState(AIController ai)
    {
        if(ai.target != null)
        {

            if (runaway)
            {
                if (Time.time - ai.timeSinceLastAttackAction > ai.maxAttackWaitTime * 1)
                {
                    direction = Quaternion.Euler(0, 0, 1.5f) * direction;
                }

                ai.rb.MovePosition(ai.transform.position + direction * Time.fixedDeltaTime * ai.moveSpeed);

                if (ai.horsebackdistanceToRunaway < (ai.transform.position - ai.target.transform.position).sqrMagnitude)
                {
                    runaway = false;
                }
                else if (Time.time - ai.timeSinceLastAttackAction > ai.maxAttackWaitTime * 2)
                {
                    runaway = false;
                }
            }
            else if (!runaway)
            {
                direction = ai.targetTransform.position - ai.transform.position;
                direction.Normalize();

                ai.rb.MovePosition(ai.transform.position + direction * Time.fixedDeltaTime * ai.moveSpeed);

                if ((ai.transform.position - ai.target.transform.position).sqrMagnitude < ai.horsebackDistanceToFight)
                {
                    ai.timeSinceLastAttackAction = Time.time;
                    if (ai.targetAIController != null)
                    {
                        ai.targetAIController.TakeHit(ai.horseAttackDamage);
                    }
                    runaway = true;
                }
            }
        }
        else
        {
            ai.rb.velocity = Vector3.zero;
        }
    }
}
