using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Item", menuName = "Scriptable Objects/SO_Item")]
public class SO_Item : ScriptableObject
{
    public enum ItemTypes
    {
        Plank = 1,
        Ore,
        Berry,
        Stick,
    }

    [SerializeField] public ItemTypes itemType;
    [SerializeField] public int stackSize = 0;
    [SerializeField] public Sprite icon;

    [SerializeField] public bool isUsable;
    [SerializeField] public bool isCraftingMaterial;

    public void UseItem() // called from outside
    {
        if (isUsable)
        {
            //OnUseItem();
        }
        else
        {
            Debug.LogWarning($"Item: {itemType.ToString()} is not usable");
        }
    }

    //protected abstract void OnUseItem();
}
