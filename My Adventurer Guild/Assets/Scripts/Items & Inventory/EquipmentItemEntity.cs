using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipmentItemEntity : ItemEntity
{
    public EquipmentItemEntity(string id, int amount) : base(id, amount)
    {
        this.id = id;
        this.Amount = amount;

        ItemsDatabase itemsDatabase = DatabasesContainer.Instance.Items;
        itemPrefab = itemsDatabase.ItemsCache[id];
    }
}
