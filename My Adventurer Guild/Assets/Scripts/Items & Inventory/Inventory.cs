using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

[System.Serializable]
public class Inventory
{
    [ReadOnly, SerializeField] private List<ItemEntity> itemsInInventory;
    [ReadOnly, SerializeField] private List<InventoryEquipableCell> equipableCells;

    public UnityAction<EquipmentItemEntity> onItemEquip;
    public UnityAction<EquipmentItemEntity> onItemDequip;

    private ItemsDatabase itemsDatabase;

    public Inventory(List<InventoryEquipableCell> equipableCells = null)
    {
        itemsInInventory = new List<ItemEntity>();
        this.equipableCells = equipableCells;

        itemsDatabase = DatabasesContainer.Instance.Items;
    }

    public void EquipItem(EquipmentItemEntity item)
    {
        if (!itemsInInventory.Contains(item))
        {
            AddItem(item.Id, 1);
        }

        foreach (InventoryEquipableCell equipableCell in equipableCells)
        {
            if (item.ItemPrefab.ItemType == equipableCell.ItemType)
            {
                if (equipableCell.EquipedItem.ItemPrefab != null)
                {
                    DequipItem(equipableCell.EquipedItem);
                }

                equipableCell.EquipedItem = item;
                onItemEquip?.Invoke(item);
                return;
            }
        }
    }

    public void EquipItem(string id)
    {
        Item itemPrefab = itemsDatabase.ItemsCache[id];

        if (itemPrefab.GetComponent<ItemEquipable>())
        {
            EquipmentItemEntity equipmentItem = GetItemByID(id) as EquipmentItemEntity;

            if (equipmentItem != null)
            {
                EquipItem(equipmentItem);
            }
            else
            {
                EquipmentItemEntity newItem = AddItem(id, 1) as EquipmentItemEntity;
                EquipItem(newItem);
            }
        }
    }

    public void DequipItem(EquipmentItemEntity item)
    {
        foreach (InventoryEquipableCell equipableCell in equipableCells)
        {
            if (item.ItemPrefab.ItemType == equipableCell.ItemType)
            {
                equipableCell.EquipedItem = null;
                onItemDequip?.Invoke(item);
                return;
            }
        }
    }

    public void AddItem(ItemAmount item)
    {
        ItemEntity existingItem = GetItemByID(item.ID);

        if (existingItem != null)
        {
            existingItem.Amount += item.Amount;
        }
        else
        {
            ItemEntity newItem = null;
            Item cachedItem = itemsDatabase.ItemsCache[item.ID];

            if (cachedItem.GetComponent<ItemEquipable>())
            {
                newItem = new EquipmentItemEntity(item.ID, item.Amount);
            }
            else
            {
                newItem = new ItemEntity(item.ID, item.Amount);
            }

            itemsInInventory.Add(newItem);
        }
    }

    public ItemEntity AddItem(string id, int amount)
    {
        ItemEntity existingItem = GetItemByID(id);

        if (existingItem != null)
        {
            existingItem.Amount += amount;
            return existingItem;
        }
        else
        {
            ItemEntity newItem = null;
            Item cachedItem = itemsDatabase.ItemsCache[id];

            if (cachedItem.GetComponent<ItemEquipable>())
            {
                newItem = new EquipmentItemEntity(id, amount);
            }
            else
            {
                newItem = new ItemEntity(id, amount);
            }

            itemsInInventory.Add(newItem);
            return newItem; 
        }
    }

    public void AddItems(ItemAmount[] items)
    {
        foreach (ItemAmount item in items)
        {
            AddItem(item);
        }
    }

    public ItemEntity GetItemByID(string id)
    {
        foreach (ItemEntity item in itemsInInventory)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return null;
    }
}
