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
                Destroy(collision.gameObject);
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
    }

}
