using UnityEngine;
using UnityEngine.EventSystems;

public class cardSwipeAction : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public float minY = 100f; // In pixels (relative to canvas)
    public float maxY = 500f;

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
        newPos.y = Mathf.Clamp(newPos.y + eventData.delta.y, minY, maxY);
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newPos.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Move the card back to its original anchored position
        rectTransform.anchoredPosition = originalPosition;
    }
}
