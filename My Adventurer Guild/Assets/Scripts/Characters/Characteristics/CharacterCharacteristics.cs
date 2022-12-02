using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterCharacteristics
{
    [SerializeField] private Characteristic health = new Characteristic("health", 0, 100, 100);
    [SerializeField] private Characteristic baseDamage = new Characteristic("base_damage", 0, 100, 5);
    [SerializeField] private Characteristic intelligence = new Characteristic("intelligence", 0, 100, 0);

    private Dictionary<string, Characteristic> characteristics;

    public CharacterCharacteristics()
    {
        characteristics = new Dictionary<string, Characteristic>();

        characteristics.Add(health.Id, health);
        characteristics.Add(baseDamage.Id, baseDamage);
        characteristics.Add(intelligence.Id, intelligence);
    }

    public Characteristic Health { get => health; }
    public Characteristic BaseDamage { get => baseDamage; }

    public float GetCharacteristicValue(string characteristicId)
    {
        return characteristics[characteristicId].Value;
    }

    public Characteristic GetCharacteristic(string characteristicId)
    {
        return characteristics[characteristicId];
    }

    public void ChangeCharacteristic(CharacteristicItem item, float multiplier = 1)
    {
        Characteristic characteristic = GetCharacteristic(item.CharacteristicId);

        characteristic.MinValue += (item.MinValue * multiplier);
        characteristic.MaxValue += (item.MaxValue * multiplier);
        characteristic.Value += (item.Value * multiplier);
    }

    public void ChangeCharacteristics(CharacteristicItem[] items, float multiplier = 1)
    {
        foreach (CharacteristicItem item in items)
        {
            ChangeCharacteristic(item, multiplier);
        }
    }
}
