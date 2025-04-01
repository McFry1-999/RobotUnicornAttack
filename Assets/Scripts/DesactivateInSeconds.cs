using UnityEngine;
using UnityEngine.Events;

public class DesactivateInSeconds : MonoBehaviour
{
   [SerializeField]
   private float secondstoDeactivate = 5f;

    public UnityEvent<GameObject> onDeactivate;

    private void Onnable()
    {
        Invoke("DeactivateObject", secondstoDeactivate);
    }

    private void DeactivateObject()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        onDeactivate?.Invoke(gameObject);
    }

}
