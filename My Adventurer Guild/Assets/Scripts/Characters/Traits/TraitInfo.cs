using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Characters/Trait")]
public class TraitInfo : ScriptableObject
{
    [SerializeField] private string id;
    [SerializeField] private string nameKey;
    [SerializeField] private string descriptionKey;

    [Space]
    [SerializeField] private CharacteristicItem[] traitCharacteristics;
    [SerializeField] private TraitInfo[] oppositeTraits;

    public string Id { get => id; }
    public string NameKey { get => nameKey; }
    public string DescriptionKey { get => descriptionKey; }
    public CharacteristicItem[] TraitCharacteristics { get => traitCharacteristics; }
    public TraitInfo[] OppositeTraits { get => oppositeTraits; }
}
