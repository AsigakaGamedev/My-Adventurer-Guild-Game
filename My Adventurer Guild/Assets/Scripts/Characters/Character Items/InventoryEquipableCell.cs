using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryEquipableCell
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private EquipmentItemEntity equipedItem;

    public InventoryEquipableCell(ItemType itemType)
    {
        this.itemType = itemType;
    }

    public ItemType ItemType { get => itemType; }
    public EquipmentItemEntity EquipedItem { get => equipedItem; set => equipedItem = value; }
}
