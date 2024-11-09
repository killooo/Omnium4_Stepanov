using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField] public AIState currentState;


    public override Character CharacterTarget => GameManager.Instance.CharacterFactory.Player;
    private float timeBetweenAttackCounter;

    
    public override void Initialize()
    {
        base.Initialize();
        LiveComponent = new CharacterLiveComponent();
        DamageComponent = new CharacterDamageComponent();
        LogicCompanent = new CharacterLogicCompanent();
        LogicCompanent.Initialize(this);
    }

   
    public override void Update()
    {
      LogicCompanent.UpdateLogic();
    }
}
