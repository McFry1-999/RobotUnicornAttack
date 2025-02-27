using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
   [SerializeField]
   private UnityEvent OnPressedButton;

   [SerializeField]

   private UnityEvent OnReleasedButton;

   public void OnPointerDown(PointerEventData eventData)
   {
    OnPressedButton?.Invoke();
   }

     public void OnPointerUp(PointerEventData eventData)
   {
    OnReleasedButton?.Invoke();
   }
}
