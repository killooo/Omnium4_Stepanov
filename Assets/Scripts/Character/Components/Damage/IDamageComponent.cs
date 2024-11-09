using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageComponent: ICharacterComponent
{
  float Damage { get; }

    void MakeDamage(Character characterTarget);
}
