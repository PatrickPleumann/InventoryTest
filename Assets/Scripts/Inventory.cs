using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
public class Inventory : MonoBehaviour
{
    [SerializeField] public List<ItemSlot> itemSlots { get; private set; }
    [SerializeField] public GameObject itemSlotPrefab;

    private void Start()
    {
        InitItemSlots();
    }

    private void InitItemSlots()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>().ToList();

        foreach (var inventorySlot in itemSlots)
        {
            CreateItemSlot(inventorySlot);
        }
    }

    private void CreateItemSlot(ItemSlot _itemSlot)
    {
        var slotItem = Instantiate(itemSlotPrefab, _itemSlot.itemSlotTransform, false);

        var image = slotItem.GetComponent<Image>();
        if (image == false)
        {
            return;
        }
        image.sprite = _itemSlot.so_Item.icon;
    }
}
