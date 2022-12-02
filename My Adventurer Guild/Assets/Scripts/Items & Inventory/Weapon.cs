using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemEquipable))]
public class Weapon : Item
{
    [Space]
    [SerializeField] private WeaponType weaponType;
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed = 1;

    public WeaponType WeaponType { get => weaponType; }
    public float Damage { get => damage; }
    public float AttackSpeed { get => attackSpeed; }
}
