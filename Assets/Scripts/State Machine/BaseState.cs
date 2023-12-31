public abstract class BaseState
{
    protected float stateTimer;
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void UpdateLate() { }
}
