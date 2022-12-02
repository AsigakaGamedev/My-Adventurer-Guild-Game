using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GuildData
{
    [SerializeField] private int sevenths;
    [SerializeField] private int seventhsPerDay;

    [Space]
    [SerializeField] private List<Character> guildCharacters;

    public GuildData(int sevenths, int seventhsPerDay)
    {
        this.sevenths = sevenths;
        this.seventhsPerDay = seventhsPerDay;

        guildCharacters = new List<Character>();
    }

    public int Sevenths { get => sevenths; set => sevenths = value; }
    public int SeventhsPerDay { get => seventhsPerDay; set => seventhsPerDay = value; }
    public List<Character> GuildCharacters { get => guildCharacters; }
}
