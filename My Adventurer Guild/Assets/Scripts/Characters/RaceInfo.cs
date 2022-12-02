using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Characters/Race")]
public class RaceInfo : ScriptableObject
{
    [SerializeField] private string raceName;

    [Space]
    [SerializeField] private CharacteristicItem[] characteristics;

    public string RaceName { get => raceName; }
    public CharacteristicItem[] Characteristics { get => characteristics; }
}
