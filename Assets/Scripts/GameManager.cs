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
    private UnityEvent onLoseGame;
    [SerializeField]
    private UnityEvent onShowGameOverScreen;

    [SerializeField]
    private float secondstoRestart = 3f;

    [SerializeField]
    private float finalsecondstoRestart = 5f;
    [SerializeField]
    private float secondstoShowGameOverScreen = 5f;

    [SerializeField]
    private UnityEvent<int> onShowTimer;

    void Awake()
    {
        secondstoRestart += secondstoShowGameOverScreen;
        finalsecondstoRestart += secondstoShowGameOverScreen;
        
    }
    void Start()
    {
        onGameStart?.Invoke();
    }

    private void ShowGameOverScreen()
    {
        onShowGameOverScreen?.Invoke();
        onShowTimer?.Invoke(3);
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

    public void LoseGame()
    {
        onLoseGame?.Invoke();
        Invoke("ShowGameOverScreen", secondstoShowGameOverScreen);
    }

}
