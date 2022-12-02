using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildController : MonoBehaviour
{
    [SerializeField] private GuildData guildData = new GuildData(10000, 0);

    public void AddCharacter(Character newCharacter)
    {
        guildData.GuildCharacters.Add(newCharacter);
    }

    public bool TryBuyCharacter(Character newCharacter, int cost)
    {
        if (cost <= guildData.Sevenths)
        {
            AddCharacter(newCharacter);
            guildData.Sevenths -= cost;
            return true;
        }

        return false;
    }
}
