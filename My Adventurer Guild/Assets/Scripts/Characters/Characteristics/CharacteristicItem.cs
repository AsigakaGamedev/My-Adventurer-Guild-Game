using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CharacteristicItem
{
    [SerializeField] private string characteristicId;
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;
    [SerializeField] private float value;

    public string CharacteristicId { get => characteristicId; }
    public float MinValue { get => minValue; }
    public float MaxValue { get => maxValue; }
    public float Value { get => value; }
}
