using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLogicCompanent : ILogicComponent
{
    private EnemyCharacter enemyCharacter;
    private float timeBetweenAttackCounter;

    public void Initialize(EnemyCharacter enemyCharacter)
    {
        this.enemyCharacter = enemyCharacter;
    }

    public void UpdateLogic()
    {
        switch (enemyCharacter.currentState)
        {
            case AIState.None:
                break;
            case AIState.MoveToTarget:
                Vector3 direction = enemyCharacter.CharacterTarget.transform.position - enemyCharacter.transform.position;
                direction.Normalize();

                enemyCharacter.MovableCompanent.Move(direction);
                enemyCharacter.MovableCompanent.Rotation(direction);

                if (Vector3.Distance(enemyCharacter.CharacterTarget.transform.position, enemyCharacter.transform.position) < enemyCharacter.characterData.AttackDistance)
                {
                    enemyCharacter.currentState = AIState.Attack;
                }

                break;
            case AIState.Attack:
                if (Vector3.Distance(enemyCharacter.CharacterTarget.transform.position, enemyCharacter.transform.position) > enemyCharacter.characterData.AttackDistance)
                {
                    enemyCharacter.currentState = AIState.MoveToTarget;
                }
                if (timeBetweenAttackCounter <= 0)
                {
                    enemyCharacter.DamageComponent.MakeDamage(enemyCharacter.CharacterTarget);
                    timeBetweenAttackCounter = enemyCharacter.characterData.TimeBetweenAttacks;
                }
                if (timeBetweenAttackCounter > 0)
                    timeBetweenAttackCounter -= Time.deltaTime;

                break;
        }
    }
}