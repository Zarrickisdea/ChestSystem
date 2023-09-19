using UnityEngine;

public class ChestLockedState : ChestState
{
    public ChestLockedState(ChestView chestView) : base(chestView)
    {
    }
    public override void Enter()
    {
        Debug.Log("ChestLockedState: Enter()");
    }
}
