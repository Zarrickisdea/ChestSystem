using UnityEngine;

public class ChestController
{
    private ChestView chestView;
    private ChestModel chestModel;

    public ChestController(ChestView view, ChestModel model)
    {
        chestModel = model;
        chestView = view;
        GameObject.Instantiate<ChestView>(chestView);
    }

    public void SetPosition(Vector3 position)
    {
        chestView.transform.position = position;
    }

    public void SetController()
    {
        chestView.SetController(this);
    }

    public void SetRewards()
    {

    }

    public float GetUnlockTime()
    {
        return chestModel.UnlockTime;
    }

    public void SetState(ChestState state)
    {
        chestView.StateMachine.ChangeState(state);
    }
}
