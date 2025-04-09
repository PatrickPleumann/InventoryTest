using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    public SO_Item so_Item;

    public Transform itemSlotTransform;

    private void Awake()
    {
        itemSlotTransform = GetComponent<Transform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        DraggableObject enteringDraggableObject = eventData.pointerDrag.GetComponent<DraggableObject>();
        ItemSlot enteringDraggableObjectItemslot = enteringDraggableObject.Origin.GetComponent<ItemSlot>();

        bool hasItemInSlot = itemSlotTransform.childCount > 0;

        SwapSlotItem(enteringDraggableObjectItemslot);




        if (hasItemInSlot == false)
        {
            if (CompareTag("Itemslot") == false)
            {
                SnapBackToOrigin(enteringDraggableObject);
            }
            else
            {
                enteringDraggableObject.SnapToTarget(this.itemSlotTransform);
            }

        }

        if (hasItemInSlot == true)
        {
            if (!CompareTag("Itemslot") == false)
            {
                SnapBackToOrigin(enteringDraggableObject);
            }
            else
            {
                DraggableObject existingDraggableObject = eventData.pointerEnter.GetComponent<DraggableObject>();
                SwapObjects(enteringDraggableObject, existingDraggableObject);
            }
        }
    }
    private void SwapSlotItem(ItemSlot _slot)
    {
        (so_Item, _slot.so_Item) = (_slot.so_Item, so_Item); // TUUUUPLE!!!!
    }
    private void SwapObjects(DraggableObject enteringDraggableObject, DraggableObject existingDraggableObject)
    {
        Transform tempOrigin = enteringDraggableObject.Origin;
        enteringDraggableObject.SnapToTarget(existingDraggableObject.Origin);
        existingDraggableObject.SnapToTarget(tempOrigin);
    }
    private void SnapBackToOrigin(DraggableObject enteringDraggableObject)
    {
        enteringDraggableObject.SnapToTarget(enteringDraggableObject.Origin);
    }

}
