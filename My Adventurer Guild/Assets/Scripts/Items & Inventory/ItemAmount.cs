using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[System.Serializable]
public struct ItemAmount
{
    [SerializeField] private string itemId;
    [SerializeField] private int minAmount;
    [SerializeField] private int maxAmount;

    public string ID { get => itemId; }
    public int Amount { get => Random.Range(minAmount, maxAmount); }
}
