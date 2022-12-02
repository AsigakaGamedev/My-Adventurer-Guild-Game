using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharactersController : MonoBehaviour
{
    [SerializeField] private string[] adventureNames;
    [SerializeField] private RaceInfo[] adventureRaces;
    [SerializeField] private TraitInfo[] adventureTraits;
    [SerializeField] private int minTraitsCount = 1;
    [SerializeField] private int maxTraitsCount = 4;

    [Space]
    [SerializeField] private Character previewCharacter;
    [SerializeField] private TraitInfo previewTrait;
    [SerializeField] private ItemAmount previewItem;

    public string[] AdventureNames { get => adventureNames; }
    public RaceInfo[] AdventureRaces { get => adventureRaces; }
    public TraitInfo[] AdventureTraits { get => adventureTraits; }

    [Button]
    public void CreatePreviewCharacter()
    {
        previewCharacter = GetRandomCharacter();
    }

    [Button]
    public void ClearPreviewCharacter()
    {
        previewCharacter = null;
    }

    [Button]
    public void AddPreviewTrait()
    {
        previewCharacter.Traits.AddTrait(previewTrait);
    }

    [Button]
    public void RemovePreviewTrait()
    {
        previewCharacter.Traits.RemoveTrait(previewTrait);
    }

    [Button]
    public void AddPreviewItem()
    {
        previewCharacter.Inventory.AddItem(previewItem);
    }

    [Button]
    public void EquipPreviewItem()
    {
        previewCharacter.Inventory.EquipItem(previewItem.ID);
    }

    public Character GetRandomCharacter()
    {
        string name = adventureNames[Random.Range(0, adventureNames.Length)];
        RaceInfo race = adventureRaces[Random.Range(0, adventureRaces.Length)];

        Character newCharacter = new Character(name, race); ;
        newCharacter.Traits.AddTraits(GetRandomTraits());

        return newCharacter;
    }

    private TraitInfo[] GetRandomTraits()
    {
        int traitsCount = Random.Range(minTraitsCount, maxTraitsCount);
        List<TraitInfo> allTraits = adventureTraits.ToList().GetRange(0, adventureTraits.Count());
        List<TraitInfo> resultTraits = new List<TraitInfo>();

        for (int i = 0; i < traitsCount; i++)
        {
            TraitInfo randomTrait = allTraits[Random.Range(0, allTraits.Count)];
            allTraits.Remove(randomTrait);
            resultTraits.Add(randomTrait);
        }

        return resultTraits.ToArray();
    }
}
