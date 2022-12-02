using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Databases/Characters Database")]
public class CharactersDatabase : ScriptableObject
{
    [SerializeField] private CharacterHandler[] characterPrefabs;

    [Space]
    [SerializeField] private string getTestCharacterId;

    private Dictionary<string, CharacterHandler> charactersCache = new Dictionary<string, CharacterHandler>();

    public Dictionary<string, CharacterHandler> CharactersCache { get => charactersCache; }

    [Button]
    public void InitializeDatabase()
    {
        charactersCache = new Dictionary<string, CharacterHandler>();

        foreach (CharacterHandler characterPrefab in characterPrefabs)
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
