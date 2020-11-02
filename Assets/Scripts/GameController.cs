using UnityEngine;

public abstract class GameController : MonoBehaviour
{
    public GameState GameState;
    public void SetState(GameState gameState)
    {
        GameState = gameState;
        GameState.EnterState();
    }
}