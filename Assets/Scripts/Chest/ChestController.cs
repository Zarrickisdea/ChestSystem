using TMPro;
using UnityEngine;

public class ChestController
{
    private ChestView chestView;
    private ChestModel chestModel;

    public TextMeshProUGUI TimerText { get; set; }
    public Slot CurrentSlot { get; set; }

    public ChestView ChestView { get => chestView; }

    public ChestController(ChestView view, ChestModel model)
    {
        chestModel = model;
        chestView = GameObject.Instantiate<ChestView>(view);
        chestView.SetController(this);
    }

    public void SetPosition(Transform position)
    {
        chestView.transform.position = position.position;
        chestView.transform.SetParent(position);
    }

    public void SetRewards()
    {
        chestModel.RewardCoins = Random.Range(chestModel.MinCoins, chestModel.MaxCoins);
        chestModel.RewardGems = Random.Range(chestModel.MinGems, chestModel.MaxGems);
    }

    public void AddRewards()
    {
        SystemManager.Instance.AddCoins(chestModel.RewardCoins);
        SystemManager.Instance.AddGems(chestModel.RewardGems);
    }

    public float GetUnlockTime()
    {
        return chestModel.UnlockTime;
    }

    public int CalculateUnlockGems()
    {
        return Mathf.RoundToInt(chestModel.UnlockTime / 60);
    }

    public void SetState(ChestState state)
    {
        chestModel.ChestState = state;
        chestView.stateMachine.ChangeState(state);
    }

    public int GetRewardCoins()
    {
        return chestModel.RewardCoins;
    }

    public int GetRewardGems()
    {
        return chestModel.RewardGems;
    }

    public void UnlockWithGems(int gems)
    {
        if (SystemManager.Instance.TotalGems < gems)
        {
            UIManager.Instance.WarningTextControl("Not enough gems!");
            return;
        }
        SystemManager.Instance.RemoveGems(gems);
        SetState(new ChestUnlockedState(chestView));
    }

    public void UnlockWithTimer()
    {
        SetState(new ChestUnlockingState(chestView));
    }

    public void SetSlot(Slot slot)
    {
        CurrentSlot = slot;
    }

    public void RemoveChest()
    {
        GameObject.Destroy(chestView.gameObject);
    }
}
