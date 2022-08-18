using UnityEngine;


public abstract class AIStateController
{
    public abstract void EnterState(AIController ai);

    public abstract void UpdateState(AIController ai);

    public abstract void FixedUpdateState(AIController ai);
}