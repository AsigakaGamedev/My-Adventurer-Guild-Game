using Enums;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentsContainer : MonoBehaviour
{
    [SerializeField] private ItemType equipmentType;
    [SerializeField] private ItemEquipable[] equipables;

    [Space]
    [ReadOnly, SerializeField] private ItemEquipable equipedItem;

    public ItemType EquipmentType { get => equipmentType; }
    public ItemEquipable EquipedItem { get => equipedItem; }

    public void EquipItem(ItemEquipable item)
    {
        ItemEquipable equipable = GetEquipable(item);

        if (equipable)
        {
            equipable.Equip();
            equipedItem = equipable;
        }
    }

    public void DequipItem(ItemEquipable item)
    {
        ItemEquipable equipable = GetEquipable(item);

        if (equipable)
        {
            equipable.Dequip();
            equipedItem = null;
        }
    }

    private ItemEquipable GetEquipable(ItemEquipable item)
    {
        foreach (ItemEquipable equipable in equipables)
        {
            if (item.Item.Id == equipable.Item.Id)
            {
                return equipable;
            }
        }

        return null;
    }
}
