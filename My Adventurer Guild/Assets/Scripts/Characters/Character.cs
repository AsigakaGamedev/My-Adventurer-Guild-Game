using Enums;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    [SerializeField] private string name;
    [Expandable, SerializeField] private RaceInfo race;

    [Space]
    [SerializeField] private CharacterCharacteristics characteristics;
    [SerializeField] private CharacterTraits traits;
    [SerializeField] private Inventory inventory;

    private int defaultCost = 100;

    public Character(string name, RaceInfo race)
    {
        this.name = name;
        this.race = race;

        characteristics = new CharacterCharacteristics();
        characteristics.ChangeCharacteristics(race.Characteristics);

        traits = new CharacterTraits();
        traits.onTraitAdd += OnTraitAdd;
        traits.onTraitRemove += OnTraitRemove;

        List<InventoryEquipableCell> equipableCells = new List<InventoryEquipableCell>();
        equipableCells.Add(new InventoryEquipableCell(ItemType.Weapon));
        equipableCells.Add(new InventoryEquipableCell(ItemType.Head));
        equipableCells.Add(new InventoryEquipableCell(ItemType.Chest));
        equipableCells.Add(new InventoryEquipableCell(ItemType.Finger));

        inventory = new Inventory(equipableCells);
    }

    public string Name { get => name; }
    public RaceInfo Race { get => race; }
    public CharacterCharacteristics Characteristics { get => characteristics; }
    public CharacterTraits Traits { get => traits; }
    public Inventory Inventory { get => inventory; }

    public void OnTraitAdd(TraitInfo trait) => characteristics.ChangeCharacteristics(trait.TraitCharacteristics, 1);
    public void OnTraitRemove(TraitInfo trait) => characteristics.ChangeCharacteristics(trait.TraitCharacteristics, -1);

    public int GetCharacterCost()
    {
        return defaultCost;
    }
}
