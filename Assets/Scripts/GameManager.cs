using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onGameStart;
    [SerializeField]
     private UnityEvent onRespawnGame;

    [SerializeField]
    private float secondtoRespawn = 3f;
    void Start()
    {
        onGameStart?.Invoke();
    }

    public void PlayerLose()
    {
        Invoke(nameof(RestartGame), secondtoRespawn);
    }

    public void RestartGame()
    {
        onRespawnGame?.Invoke();
    }
}
