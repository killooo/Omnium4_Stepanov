using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILogicComponent
{
    void Initialize(EnemyCharacter enemyCharacter);
    void UpdateLogic();
}