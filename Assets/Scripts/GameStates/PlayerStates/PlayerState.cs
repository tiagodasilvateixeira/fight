public abstract class PlayerState
{
    public PlayerController PlayerController { get; set; }
    public PlayerState(PlayerController controller)
    {
    }
    public PlayerState()
    {
    }
    public abstract void EnterState();
    public abstract void Update();
}