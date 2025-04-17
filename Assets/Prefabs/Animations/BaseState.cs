

public  abstract class BaseState
{
    public float speed;
    public abstract void EnterState(StateManager state);
    public abstract void UpdateState(StateManager state);
    public abstract void ExitState(StateManager state);
}
