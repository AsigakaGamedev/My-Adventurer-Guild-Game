using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private string characterID;

    [Space]
    [SerializeField] private CharacterHealth heatlh;

    [Space]
    [ReadOnly, SerializeField] private Character character;

    public Character Character { get => character;
        set 
        {
            character = value;
            heatlh.SetMaxHealth(character.Characteristics.Health.MaxValue);
        }
    }

    public CharacterHealth Heatlh { get => heatlh; }
    public string CharacterID { get => characterID; }
}
