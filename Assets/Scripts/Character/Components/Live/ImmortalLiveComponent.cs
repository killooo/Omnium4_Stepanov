using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmortalLiveComponent : ILiveComponent
{
    private Character selfCharacter;

    public event Action<Character> OnCharacterDeath;

    public void Initialize(Character selfCharacter)
    {
        this.selfCharacter = selfCharacter;
    }
    public float MaxHealth  => 1;
   public float Health  => 1;

    public void SetDamage(float damage)
    {
        Debug.Log("I am Immortal!!!");
    }
}
