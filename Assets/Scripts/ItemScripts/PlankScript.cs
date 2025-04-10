using UnityEngine;

public class PlankScript : Interactable
{
    public override void Interact()
    {
        Destroy(this.gameObject);
    }
}
