using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [Space]
    [ReadOnly, SerializeField] private float health;
    [ReadOnly, SerializeField] private float maxHealth;

    public float Health { get => health; set => health = Mathf.Clamp(value, 0, maxHealth); }

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("умер");
        }
    }

    public void Heal(float heal)
    {

    }
}
