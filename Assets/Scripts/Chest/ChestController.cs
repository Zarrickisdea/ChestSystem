using UnityEngine;

public class ChestController
{
    private ChestView chestView;
    private ChestModel chestModel;

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
        SystemManager.Instance.RemoveGems(gems);
        SetState(new ChestUnlockedState(chestView));
    }

    public void UnlockWithTimer()
    {
        SetState(new ChestUnlockingState(chestView));
    }
}
