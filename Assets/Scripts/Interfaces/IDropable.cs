using UnityEngine;

public interface IDropable : IItem
{
    public void DropItem(IItem _item);
}
