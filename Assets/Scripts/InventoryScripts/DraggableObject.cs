using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform slotTransform;
    public RectTransform SlotRectTransform { get; private set; }

    private Image slotImage;
    public Transform Origin { get; set; }

    private void Awake()
    {
        slotImage = GetComponent<Image>();
        slotTransform = GetComponent<Transform>();
        SlotRectTransform = GetComponent<RectTransform>();
        Origin = slotTransform.parent;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        slotTransform.SetParent(slotTransform.root);
        slotTransform.SetAsLastSibling();
        slotImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        slotTransform.position = Mouse.current.position.ReadValue();
    }

    public void OnEndDrag(PointerEventData eventData) //try to solve NullRef when var itemSlot can´t get any data over pointerDrag or pointerEnter.
    {
        slotImage.raycastTarget = true;

        bool validSlot = eventData.pointerDrag.transform.parent.TryGetComponent<ItemSlot>(out _);

        if (!validSlot)
        {
            SnapToTarget(Origin);
        }
    }

    public void SnapToTarget(Transform _target)
    {
        slotTransform.SetParent(_target);
        SlotRectTransform.anchoredPosition = Vector2.zero;
        Origin = _target;
    }
}
