using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabasesContainer : MonoBehaviour
{
    [Expandable, SerializeField] private ItemsDatabase items;
    [Expandable, SerializeField] private CharactersDatabase characters;

    public static DatabasesContainer Instance;

    public ItemsDatabase Items { get => items; }
    public CharactersDatabase Characters { get => characters; }

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;

        items.InitializeDatabase();
        characters.InitializeDatabase();
    }
}
