using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using System;

public class ItemSlot : EventTrigger
{
    [SerializeField] public SO_Item so_Item;

    public Transform itemSlotTransform;

    private void Awake()
    {
        itemSlotTransform = GetComponent<Transform>();
    }

    public override void OnDrop(PointerEventData eventData)
    {
        DraggableObject enteringDraggableObject = eventData.pointerDrag.GetComponent<DraggableObject>();
        ItemSlot enteringDraggableObjectSkillslot = enteringDraggableObject.Origin.GetComponent<ItemSlot>();

        bool hasSkillInSlot = itemSlotTransform.childCount > 0;

        SwapSlotItem(enteringDraggableObjectSkillslot);

        if (hasSkillInSlot == false)
        {
            enteringDraggableObject.SnapToTarget(this.itemSlotTransform);
        }

        if (hasSkillInSlot == true)
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
