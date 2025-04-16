using UnityEngine;

public class PlankScript : MonoBehaviour, ICanBePickedUp, IAmInteractable
{
    [SerializeField] private SO_Item item;

    public void Interact(Transform interactingObject)
    {
        if (interactingObject.gameObject.TryGetComponent(out IAmInventory container))
            PickUp(container);
    }

    public void PickUp(IAmInventory container)
    {
        container.GetItemIntoSlot(item);
        Destroy(this.gameObject);
    }
}