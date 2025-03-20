using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onGameStart;
    [SerializeField]
     private UnityEvent onRespawnGame;

    [SerializeField]
    private UnityEvent onFinishGame;

    [SerializeField]
    private float secondstoRestart = 3f;

    [SerializeField]
    private float finalsecondstoRestart = 5f;

    void Start()
    {
        onGameStart?.Invoke();
    }

    public void RespawnGame()
    {
        Invoke("RestartGame",secondstoRestart);
    }

    public void FinishGame()
    {
        onFinishGame?.Invoke();
        Invoke("Start", finalsecondstoRestart);
        Invoke("RestartGame", finalsecondstoRestart);
    }
     public void RestartGame()
    {
        onRespawnGame?.Invoke();
    }

}
