using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TrashSlot : MonoBehaviour, IDropHandler
{
    

    [SerializeField] private Transform playerTransform;
    public void OnDrop(PointerEventData eventData)
    {
        DraggableObject enteringObject = eventData.pointerDrag.GetComponent<DraggableObject>();
        ItemSlot enteringSlot = enteringObject.Origin.GetComponent<ItemSlot>();

        DropItemToGround(enteringSlot.so_Item);
        ClearDraggableObject(enteringObject);
        ClearSOItem(enteringSlot);
    }

    private void DropItemToGround(SO_Item _item)
    {
        Instantiate(_item.itemPrefab, playerTransform.position, Quaternion.identity);
    }

    private void ClearDraggableObject(DraggableObject _object)
    {
        Destroy(_object.gameObject);
    }

    private void ClearSOItem(ItemSlot _slot)
    {
        _slot.so_Item = null;
    }
}
