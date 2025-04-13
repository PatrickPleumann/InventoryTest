using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
public class Inventory : MonoBehaviour
{
    [SerializeField] public List<ItemSlot> itemSlots { get; private set; }
    [SerializeField] public GameObject itemSlotPrefab; //slotItem
    [SerializeField] public List<SO_Item> itemsInInventory; //trying...

    private void Start()
    {
        InitItemSlots();
    }

  // need to find a way either to use a list of SO_Items and get their components, or add a method which assigns SO_Item to any free ItemSlot
    private void InitItemSlots()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>().ToList();
        itemsInInventory = GetComponents<SO_Item>().ToList(); // trying...

        foreach (var inventorySlot in itemSlots/*trying*/)
        {
            if (inventorySlot.so_Item == false)
            {
                continue;
            }

            CreateItemSlot(inventorySlot);
        }
    }

    private void CreateItemSlot(ItemSlot _itemSlot)
    {
        var slotItem = Instantiate(itemSlotPrefab, _itemSlot.itemSlotTransform, false); // method needs parent transform, maybe use other overload method
        
        var image = slotItem.GetComponent<Image>();
        if (image == false)
        {
            return;
        }
        image.sprite = _itemSlot.so_Item.icon;
       
    }
}
