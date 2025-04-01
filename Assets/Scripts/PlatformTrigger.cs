using Unity.VisualScripting;
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
            other.gameObject.SetActive(false);
            onPlatformTrigered?.Invoke();
        }
    }
}
