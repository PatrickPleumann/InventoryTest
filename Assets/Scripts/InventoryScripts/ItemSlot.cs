using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Runtime.CompilerServices;
using UnityEngineInternal;

public class ItemSlot : MonoBehaviour//, IDropHandler
{
    //OnDrop is called without IDropHandler, but var itemSlot in OnEndDrag is causing NullRef

    [SerializeField]
    public SO_Item so_Item;

    public Transform itemSlotTransform;

    public bool hasSlotItem = false;

    private void Awake()
    {
        itemSlotTransform = GetComponent<Transform>();
    }

    /// <summary>
    /// Method is implemented by IDropHandler: Logic for swapping/snapping objects which are dragged inside the inventory.
    /// </summary>
    /// <param name="eventData">Event data from PointerEventData. Event data is usually a DraggableObject </param>
    public void OnDrop(PointerEventData eventData)
    {
        DraggableObject enteringDraggableObject = eventData.pointerDrag.GetComponent<DraggableObject>();
        ItemSlot enteringDraggableObjectItemslot = enteringDraggableObject.Origin.GetComponent<ItemSlot>();

        bool hasItemInSlot = itemSlotTransform.childCount > 0;

        SwapSlotItem(enteringDraggableObjectItemslot);


        if (hasItemInSlot == false)
        {
            enteringDraggableObject.SnapToTarget(itemSlotTransform);
        }

        if (hasItemInSlot == true)
        {
            DraggableObject existingDraggableObject = eventData.pointerEnter.GetComponent<DraggableObject>();
            SwapObjects(enteringDraggableObject, existingDraggableObject);
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
}
