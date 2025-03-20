using UnityEngine;
using UnityEngine.Events;

public class PlatformTrigger : MonoBehaviour
{
     [SerializeField]
     private UnityEvent onPlatformTrigered;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeadZone"))
        {
            Destroy(other.gameObject);
            onPlatformTrigered?.Invoke();
        }
    }
}
