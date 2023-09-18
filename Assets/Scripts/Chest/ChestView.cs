using UnityEngine;

public class ChestView : MonoBehaviour
{
    private ChestController chestController;

    private StateMachine stateMachine;

    private ChestQueuedState chestQueuedState;
    private ChestLockedState chestLockedState;
    private ChestUnlockingState chestUnlockingState;
    private ChestUnlockedState chestUnlockedState;

    public ChestController ChestController => chestController;
    public StateMachine StateMachine => stateMachine;

    private void Awake()
    {
        stateMachine = new StateMachine();
        chestQueuedState = new ChestQueuedState(this);
        chestLockedState = new ChestLockedState(this);
        chestUnlockingState = new ChestUnlockingState(this);
        chestUnlockedState = new ChestUnlockedState(this);
    }

    private void Start()
    {
        stateMachine.Initialize(chestQueuedState);
    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateLogic();
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentState.UpdatePhysics();
    }

    private void LateUpdate()
    {
        stateMachine.CurrentState.UpdateLate();
    }

    public void SetController(ChestController chestController)
    {
        this.chestController = chestController;
    }

}
