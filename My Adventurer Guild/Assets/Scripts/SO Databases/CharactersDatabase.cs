using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Databases/Characters Database")]
public class CharactersDatabase : ScriptableObject
{
    [SerializeField] private CharacterController[] characterPrefabs;

    [Space]
    [SerializeField] private string getTestCharacterId;

    private Dictionary<string, CharacterController> charactersCache = new Dictionary<string, CharacterController>();

    public Dictionary<string, CharacterController> CharactersCache { get => charactersCache; }

    [Button]
    public void InitializeDatabase()
    {
        charactersCache = new Dictionary<string, CharacterController>();

        foreach (CharacterController characterPrefab in characterPrefabs)
        {
            charactersCache.Add(characterPrefab.CharacterID, characterPrefab);
        }
    }

    [Button]
    public void TestGetCharacterPrefab()
    {
        Debug.Log(charactersCache[getTestCharacterId].name);
    }
}
