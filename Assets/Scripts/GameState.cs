public abstract class GameState
{
    public GameState(GameController controller)
    {
    }
    public GameState()
    {
    }
    public abstract void EnterState();
    public abstract void Update();
}