using UnityEngine;

public interface IPickUpAble : IItem
{
    public void PickUpItem(IItem _item);
}
