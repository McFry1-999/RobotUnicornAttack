using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField]

    private UnityEvent OnPlayerLose;

    private Dash dash;

    [SerializeField]
    private UnityEvent <Transform> onObstacleDestroyed;

    [SerializeField]
    private UnityEvent <Transform> onCollisionDie;

    [SerializeField]
    private UnityEvent OnCoinCollected;

    private void Start()
    {
        dash = GetComponent<Dash>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            if(dash.IsDashing)
            {
                onObstacleDestroyed?.Invoke(transform);
                collision.gameObject.SetActive(false);
            }
            else
            {
                onCollisionDie?.Invoke(transform);
                OnPlayerLose?.Invoke();
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone"))
        {
            onCollisionDie?.Invoke(transform);
            OnPlayerLose?.Invoke();
        }
        else if (other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            OnCoinCollected?.Invoke();
        }
    }

}
