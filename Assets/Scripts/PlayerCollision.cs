using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField]

    private UnityEvent OnPlayerLose;

    private Dash dash;

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
                Destroy(collision.gameObject);
            }
            else
            {
                OnPlayerLose?.Invoke();
            }
        }
        
    }

}
