using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    [SerializeField] private CharacterType characterType;
    [SerializeField]public CharacterData characterData;


    public virtual Character CharacterTarget { get; }
    public CharacterType CharacterType => characterType;
    public CharacterData CharacterData => characterData;
    public IMovable MovableCompanent { get; protected set; }
    public ILiveComponent LiveComponent { get; protected set; }

    public IDamageComponent DamageComponent { get; protected set; }

    public ILogicComponent LogicCompanent { get; protected set; }
    public virtual void Initialize()
    {
        MovableCompanent = new CharacterMovementCompanent();
        MovableCompanent.Initialize(characterData);

    }

    public abstract void Update();
}
