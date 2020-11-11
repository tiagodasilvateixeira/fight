using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class GameController : MonoBehaviour
{
    public GameState GameState;
    public void SetState(GameState gameState)
    {
        GameState = gameState;
        GameState.EnterState();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}