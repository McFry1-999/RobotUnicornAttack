using UnityEngine;
using UnityEngine.Events;

public class Dash : MonoBehaviour
{
    [SerializeField]

    private float duration = 0.5f;

    [SerializeField]

    private float inactiveDuration = 0.5f;
    
    [SerializeField]
    private UnityEvent onDash;
    [SerializeField]

    private UnityEvent onStopDash;

    private bool canDash = true;
    private bool isDashing;
    public bool IsDashing {get => isDashing;}

    private bool DashEnabled = true;

    public void SetDashEnabled (bool enabled)
    {
        DashEnabled = enabled;
    }

    public void DashAction()
    {
        if(!isDashing && canDash && DashEnabled)
        {
            canDash = false;
            onDash?.Invoke();
            isDashing = true;
            Invoke(nameof(StopDash), duration);
        }
    }

    private void StopDash()
    {
        onStopDash?.Invoke();
        isDashing = false;
        Invoke(nameof(EnableDash), inactiveDuration);
    }
    

    private void EnableDash()
    {
        canDash = true;
    }


}
