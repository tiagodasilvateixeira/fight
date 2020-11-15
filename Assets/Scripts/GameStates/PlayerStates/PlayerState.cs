public abstract class PlayerState
{
    public PlayerState(IPlayer controller)
    {
    }
    public PlayerState()
    {
    }
    public abstract void EnterState();
    public abstract void Update();
}