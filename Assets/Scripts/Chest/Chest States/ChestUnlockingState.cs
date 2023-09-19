using UnityEngine;

public class ChestUnlockingState : ChestState
{
    private float unlockTime;
    public ChestUnlockingState(ChestView chestView) : base(chestView)
    {
    }
    public override void Enter()
    {
        unlockTime = chestView.ChestController.GetUnlockTime();
    }

    public override void UpdateLogic()
    {
        unlockTime -= Time.deltaTime;
        if (unlockTime <= 0)
        {
            chestView.ChestController.SetState(new ChestUnlockedState(chestView));
        }
    }

    public override void UpdateLate()
    {
        UIManager.Instance.ChestUnlockTimerControl(unlockTime);
    }

    public override void Exit()
    {
        unlockTime = 0;
    }
}
