using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CharacterTraits
{
    [ReadOnly, SerializeField] private List<TraitInfo> traits;

    public UnityAction<TraitInfo> onTraitAdd;
    public UnityAction<TraitInfo> onTraitRemove;

    public CharacterTraits()
    {
        traits = new List<TraitInfo>();
    }

    public void AddTrait(TraitInfo newTrait)
    {
        if (!traits.Contains(newTrait))
        {
            RemoveTraits(newTrait.OppositeTraits);

            onTraitAdd.Invoke(newTrait);
            traits.Add(newTrait);
        }
    }

    public void AddTraits(TraitInfo[] newTraits)
    {
        foreach (TraitInfo newTrait in newTraits)
        {
            AddTrait(newTrait);
        }
    }

    public void RemoveTrait(TraitInfo newTrait)
    {
        if (traits.Contains(newTrait))
        {
            onTraitRemove.Invoke(newTrait);
            traits.Remove(newTrait);
        }
    }

    public void RemoveTraits(TraitInfo[] newTraits)
    {
        foreach (TraitInfo newTrait in newTraits)
        {
            RemoveTrait(newTrait);
        }
    }

    /*public TraitInfo GetTraitByInfo(TraitInfo targetTrait)
    {
        foreach (TraitInfo trait in traits)
        {
            if (trait == targetTrait)
            {
                return trait;
            }
        }

        return null;
    }*/
}
