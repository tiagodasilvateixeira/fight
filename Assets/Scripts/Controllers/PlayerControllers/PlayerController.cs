using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class PlayerController : MonoBehaviour
{
    public PlayerState PlayerState;
    public void SetState(PlayerState playerState)
    {
        PlayerState = playerState;
        PlayerState.EnterState();
    }
}