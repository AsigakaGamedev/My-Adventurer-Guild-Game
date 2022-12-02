using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Characteristic
{
    [SerializeField] private string id;
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;
    [SerializeField] private float value;

    public Characteristic(string id, float minValue, float maxValue)
    {
        this.id = id;
        this.minValue = minValue;
        this.maxValue = maxValue;
    }

    public Characteristic(string id, float minValue, float maxValue, float defaultValue)
    {
        this.id = id;
        this.minValue = minValue;
        this.maxValue = maxValue;
        Value = defaultValue;
    }

    public string Id { get => id; }
    public float Value { get => value; set => this.value = Mathf.Clamp(value, minValue, maxValue); }
    public float MinValue { get => minValue; set => minValue = value; }
    public float MaxValue { get => maxValue; set => maxValue = value; }
}
