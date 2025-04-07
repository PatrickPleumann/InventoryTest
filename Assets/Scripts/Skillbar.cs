using NUnit.Framework;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Skillbar : MonoBehaviour
{
    [SerializeField] public List<SkillSlot> skillSlots { get; private set; }
    [SerializeField] public GameObject slotItemPrefab;

    private void Start()
    {
        InitSkillSlots();
    }

    private void InitSkillSlots()
    {
        skillSlots = GetComponentsInChildren<SkillSlot>().ToList();

        foreach (var skillSlot in skillSlots)
        {
            if (skillSlot.SO_Skill == false)
            {
                continue;
            }

            CreateSlotItem(skillSlot);
        }
    }

    private void CreateSlotItem(SkillSlot _skillslot)
    {
        var slotItem = Instantiate(slotItemPrefab, _skillslot.skillSlotTransform, false);

        var image = slotItem.GetComponent<Image>();
        if (image == false) 
        {
            return;
        }

        image.sprite = _skillslot.SO_Skill.icon;
    }
}
