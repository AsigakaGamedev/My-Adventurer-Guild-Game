using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GuildController guildController;
    [SerializeField] private CharactersController charactersController;

    [Space]
    [SerializeField] private int minCharactersForSale = 1;
    [SerializeField] private int maxCharactersForSale = 6;

    [Space]
    [SerializeField] private int characterForSaleBuyIndex;
    [SerializeField] private List<Character> charactersForSale;

    public List<Character> CharactersForSale { get => charactersForSale; }

    [Button]
    public void FillCharactersForSale()
    {
        charactersForSale = new List<Character>();

        int charactersCount = Random.Range(minCharactersForSale, maxCharactersForSale);

        for (int i = 0; i < charactersCount; i++)
        {
            Character newCharacter = charactersController.GetRandomCharacter();
            charactersForSale.Add(newCharacter);
        }
    }

    [Button]
    public void TestBuyCharacter()
    {
        BuyCharacter(charactersForSale[characterForSaleBuyIndex]);
    }

    public void BuyCharacter(Character character)
    {
        if (charactersForSale.Contains(character))
        {
            if (guildController.TryBuyCharacter(character, character.GetCharacterCost()))
            {
                charactersForSale.Remove(character);
            }
        }
    }
}
