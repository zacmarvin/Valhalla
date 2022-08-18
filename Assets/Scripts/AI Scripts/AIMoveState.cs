using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveState : AIStateController
{
    public override void EnterState(AIController ai)
    {
        
    }

    public override void UpdateState(AIController ai)
    {
        //if (ai.target != null)
        //{
        //    //Vector2 positionToMoveTo = ai.transform.position - ai.target.transform.position;
        //    //positionToMoveTo.Normalize();
        //    //positionToMoveTo *= (Time.deltaTime / ai.moveSpeed);
        //    //ai.rb.MovePosition(positionToMoveTo);
        //    ai.transform.position = Vector3.MoveTowards(ai.transform.position, ai.targetTransform.position, Time.deltaTime * ai.moveSpeed);
        //}

    }

    public override void FixedUpdateState(AIController ai)
    {
        if (ai.target != null)
        {
            Vector3 direction = ai.targetTransform.position - ai.transform.position;
            direction.Normalize();
            ai.rb.MovePosition(ai.transform.position + direction * Time.fixedDeltaTime * ai.moveSpeed);
        } else
        {
            ai.rb.velocity = Vector3.zero;
        }
    }
}
