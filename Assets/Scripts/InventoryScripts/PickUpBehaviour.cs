using Unity.VisualScripting;
using UnityEngine;

public class PickUpBehaviour : MonoBehaviour
{
    [SerializeField] public Inventory inventoryBag;

    private void Awake()
    {
        inventoryBag = GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ItemSlot temp = other.GetComponent<ItemSlot>();

        if (temp == false)
        {
            return;
        }

        PickUp(temp);
    }

    private void PickUp(ItemSlot obj)
    {
        inventoryBag.itemSlots.Add(obj);
    }
}
