using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DoubleClickButton : MonoBehaviour, IPointerClickHandler
{


    public UnityEvent OnDoubleClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (eventData.clickCount == 2)
            {
                OnDoubleClick?.Invoke();
            }
        }
    }
}
