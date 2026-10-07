using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IEndDragHandler
{


    private RectTransform rectTransform;
    private Vector2 originalPosition;




    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector2 newPos = rectTransform.anchoredPosition;
               //Debug.Log("Drag");
        transform.position = Input.mousePosition;
    }



        public void OnEndDrag(PointerEventData eventData)
    {
        // Move the card back to its original anchored position
        rectTransform.anchoredPosition = originalPosition;
    }
}
