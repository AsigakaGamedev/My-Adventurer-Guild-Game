using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string id;
    [SerializeField] private string nameKey;
    [SerializeField] private string descriptionKey;
    [SerializeField] private ItemType itemType;

    public string Id { get => id; }
    public string NameKey { get => nameKey; }
    public string DescriptionKey { get => descriptionKey; }
    public ItemType ItemType { get => itemType; }
}
