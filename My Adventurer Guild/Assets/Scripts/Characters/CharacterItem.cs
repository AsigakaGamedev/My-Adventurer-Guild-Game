using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CharacterItem
{
    [SerializeField] private string characterId;
    [SerializeField] private CharacterController characterPrefab;

    public string CharacterId { get => characterId; }
    public CharacterController CharacterPrefab { get => characterPrefab; }
}
