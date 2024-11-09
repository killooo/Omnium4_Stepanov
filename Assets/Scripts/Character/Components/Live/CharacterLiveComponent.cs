using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLiveComponent : ILiveComponent
{
    private Character selfCharacter;

    public void Initialize(Character selfCharacter)
    {
        this.selfCharacter = selfCharacter;
    }
    private float currentHealth;

    public event Action<Character> OnCharacterDeath;

    public float MaxHealth 
    { 
        get => 50; 
        protected set { return; } 
    }
    public float Health 
    { 
        get => currentHealth;
        protected set 
        { 
            currentHealth = value;
            if (currentHealth > MaxHealth)
                currentHealth = MaxHealth;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                SetDeath();
            }
        }
    }


    public CharacterLiveComponent() 
    {
        Health = MaxHealth;
    }
    public void SetDamage(float damage)
    {
        Health -= damage;
        Debug.Log("Get damage =" + damage);
    }

    private void SetDeath( )
    {
        OnCharacterDeath?.Invoke(selfCharacter);
        Debug.Log("Character is death");
    }
}
