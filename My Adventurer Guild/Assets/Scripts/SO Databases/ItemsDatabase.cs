using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Databases/Items Database")]
public class ItemsDatabase : ScriptableObject
{
    [SerializeField] private Item[] itemPrefabs;

    [Space]
    [SerializeField] private string getTestItemId;

    private Dictionary<string, Item> itemsCache = new Dictionary<string, Item>();

    public Dictionary<string, Item> ItemsCache { get => itemsCache; }

    [Button]
    public void InitializeDatabase()
    {
        itemsCache = new Dictionary<string, Item>();

        foreach (Item itemPrefab in itemPrefabs)
        {
            itemsCache.Add(itemPrefab.Id, itemPrefab);
        }
    }

    [Button]
    public void TestGetItemPrefab()
    {
        Debug.Log(itemsCache[getTestItemId].name);
    }
}
