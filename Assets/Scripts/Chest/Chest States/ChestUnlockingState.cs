using UnityEngine;

public class ChestUnlockingState : ChestState
{
    public ChestUnlockingState(ChestView chestView) : base(chestView)
    {
    }
    public override void Enter()
    {
        stateTimer = chestView.ChestController.GetUnlockTime();
        UIManager.Instance.SetObjectState(chestView.ChestController.TimerText.gameObject, true);
    }

    public override void UpdateLogic()
    {
        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0)
        {
            chestView.ChestController.SetState(new ChestUnlockedState(chestView));
        }
    }

    public override void UpdateLate()
    {
        UIManager.Instance.ChestUnlockTimerControl(chestView.ChestController.TimerText, stateTimer);
    }

    public override void Exit()
    {
        stateTimer = 0;
    }
}
