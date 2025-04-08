using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;



public class SkillSlot : MonoBehaviour, IDropHandler
{
    public SO_Skill SO_Skill;

    public Transform skillSlotTransform { get; private set; }

    private void Awake()
    {
        skillSlotTransform = GetComponent<Transform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        DraggableObject enteringDraggableObject = eventData.pointerDrag.GetComponent<DraggableObject>();
        SkillSlot enteringDraggableObjectSkillslot = enteringDraggableObject.Origin.GetComponent<SkillSlot>();

        bool hasSkillInSlot = skillSlotTransform.childCount > 0;

        SwapSlotItem(enteringDraggableObjectSkillslot);

        if (hasSkillInSlot == false)
        {
            enteringDraggableObject.SnapToTarget(this.skillSlotTransform);
        }

        if (hasSkillInSlot == true)
        {
            DraggableObject existingDraggableObject = eventData.pointerEnter.GetComponent<DraggableObject>();
            SwapObjects(enteringDraggableObject, existingDraggableObject);
        }
    }

    private void SwapSlotItem(SkillSlot _slot)
    {
        (SO_Skill, _slot.SO_Skill) = (_slot.SO_Skill, SO_Skill); // TUUUUPLE!!!!
    }

    private void SwapObjects(DraggableObject enteringDraggableObject, DraggableObject existingDraggableObject)
    {
        Transform tempOrigin = enteringDraggableObject.Origin;
        enteringDraggableObject.SnapToTarget(existingDraggableObject.Origin);
        existingDraggableObject.SnapToTarget(tempOrigin);
    }
}
