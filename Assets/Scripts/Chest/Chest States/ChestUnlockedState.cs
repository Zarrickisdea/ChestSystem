using UnityEngine;

public class ChestUnlockedState : ChestState
{    
    public ChestUnlockedState(ChestView chestView) : base(chestView)
    {
    }
    public override void Enter()
    {
        chestView.Animator.SetBool("Open", true);
        chestView.ChestController.AddRewards();
        UIManager.Instance.ChestSpawnControl();
    }
}
