public class ChestQueuedState : ChestState
{    
    public ChestQueuedState(ChestView chestView) : base(chestView)
    {
    }
    public override void Enter()
    {
        chestView.ChestController.SetRewards();
        chestView.Animator.SetBool("Open", false);
    }
}
