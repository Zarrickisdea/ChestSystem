using UnityEngine;

public class ChestUnlockedState : ChestState
{
    public ChestUnlockedState(ChestView chestView) : base(chestView)
    {
    }
    public override void Enter()
    {
        stateTimer = 3f;
        UIManager.Instance.SetObjectState(chestView.ChestController.TimerText.gameObject, false);
        chestView.Animator.SetBool("Open", true);
        chestView.ChestController.AddRewards();
        UIManager.Instance.SetRewardsPanel(chestView.ChestController.CurrentSlot.rewardsPanel, chestView.ChestController.GetRewardCoins(), chestView.ChestController.GetRewardGems());
        UIManager.Instance.UpdateCurrencyText();
        chestView.ChestController.CurrentSlot.unlockButton.interactable = false;
    }

    public override void UpdateLogic()
    {
        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0)
        {
            Exit();
        }
    }

    public override void Exit()
    {
        stateTimer = 0;
        chestView.ChestController.CurrentSlot.unlockButton.interactable = true;
        UIManager.Instance.SetObjectState(chestView.ChestController.CurrentSlot.rewardsPanel, false);
        ChestSlotManager.Instance.AddToSlotQueue(chestView.ChestController.CurrentSlot);
        chestView.ChestController.RemoveChest();
        ChestManager.Instance.RemoveChest();
        UIManager.Instance.ChestSpawnControl();
    }
}
