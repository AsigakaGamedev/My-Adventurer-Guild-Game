using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEntity
{
    [SerializeField] protected string id;
    [SerializeField] protected Item itemPrefab;

    public int Amount;

    public ItemEntity(string id, int amount)
    {
        this.id = id;
        Amount = amount;

        ItemsDatabase itemsDatabase = DatabasesContainer.Instance.Items;
        itemPrefab = itemsDatabase.ItemsCache[id];
    }

    public string Id { get => id; }
    public Item ItemPrefab { get => itemPrefab; }
}
