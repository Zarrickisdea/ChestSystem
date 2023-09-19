using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private ChestController chestController;

    public StateMachine stateMachine { get; private set; }

    public ChestQueuedState chestQueuedState { get; private set; }
    public ChestUnlockingState chestUnlockingState { get; private set; }
    public ChestUnlockedState chestUnlockedState { get; private set; }

    public ChestController ChestController
    {
        get => chestController;
    }

    public Animator Animator
    {
        get => animator;
    }

    private void Awake()
    {
        stateMachine = new StateMachine();
        chestQueuedState = new ChestQueuedState(this);
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
