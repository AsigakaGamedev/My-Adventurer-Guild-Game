using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquipable : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private Animator animator;
    [SerializeField] private int animatorLayer = 1;

    [Space]
    [AnimatorParam(nameof(Animator)), SerializeField] private string equipAnimationKey;
    [AnimatorParam(nameof(Animator)), SerializeField] private string dequipAnimationKey;

    public string EquipAnimationKey { get => equipAnimationKey; }
    public string DequipAnimationKey { get => dequipAnimationKey; }
    public Item Item { get => item; }

    public void Equip()
    {
        animator.Play(equipAnimationKey, animatorLayer);
    }

    public void Dequip()
    {
        animator.Play(dequipAnimationKey, animatorLayer);
    }
}
