using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
public class Inventory : MonoBehaviour, IAmInventory
{
    [SerializeField] public List<ItemSlot> itemSlots { get; private set; }
    [SerializeField] public GameObject itemSlotPrefab; //slotItem

    private bool itemSlotsHasComponents;
    //private bool inventoryIsOpen;

    private void Awake()
    {
        itemSlotsHasComponents = false;
    }
    private void OnEnable()
    {
        InitItemSlots();
    }

    private void InitItemSlots()
    {
        if (itemSlotsHasComponents == false)
        {
            itemSlots = GetComponentsInChildren<ItemSlot>().ToList();
            itemSlotsHasComponents = true;
        }

        foreach (var inventorySlot in itemSlots)
        {
            if (inventorySlot.so_Item == false)
            {
                continue;
            }
            if (inventorySlot.transform.childCount == 0)
            {
                CreateItemSlot(inventorySlot);
            }
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

    public void GetItemIntoSlot(SO_Item _item)
    {
        foreach (var inventorySlot in itemSlots)
        {
            if (inventorySlot.so_Item == true)
            {
                continue;
            }
            if (inventorySlot.so_Item == false)
            {
                inventorySlot.so_Item = _item;
                if (gameObject.activeSelf == true)
                {
                    InitItemSlots();
                }
                return;
            }
        }
    }

    public void EnableDisableInventory()
    {
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}
