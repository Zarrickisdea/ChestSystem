using UnityEngine;

public class ChestUnlockedState : ChestState
{    
    public ChestUnlockedState(ChestView chestView) : base(chestView)
    {
    }
    public override void Enter()
    {
        Debug.Log("ChestUnlockedState: Enter()");
    }
}
