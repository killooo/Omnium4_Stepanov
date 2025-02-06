using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class CharacterFactory : MonoBehaviour
{
    [SerializeField]
    private Character _playerPrefab;

    [Space]
    [SerializeField]
    private Character _enemyPrefab;


    public PlayerCharacter PlayerCharacter { get; private set; }


    private Dictionary<CharacterType, Queue<Character>> pool = new Dictionary<CharacterType, Queue<Character>>();

    private List<Character> activePool = new();


    public List<Character> ActivePool => activePool;


    public Character CreateCharacter(CharacterType characterType)
    {
        Character character = GetFromPool(characterType);

 
        if (character == null)
        {
            character = InstantiateCharacter(characterType);
        }

        activePool.Add(character);
        character.Initialize();

        if (character is PlayerCharacter player)
            PlayerCharacter = player;

        return character;
    }


    public void ReturnToPool(Character character)
    {
        activePool.Remove(character);
        var characterType = character.CharacterType;
        pool[characterType].Enqueue(character);
    }

  
    private Character GetFromPool(CharacterType characterType)
    {
        if (!pool.ContainsKey(characterType))
        {
            pool.Add(characterType, new Queue<Character>());
            return null;
        }

        if (pool[characterType].Count > 0)
        {
            return pool[characterType].Dequeue();
        }
        return null;
    }


    private Character InstantiateCharacter(CharacterType characterType)
    {
        Character characterObject = null;

        switch (characterType)
        {
            case CharacterType.DefaultPlayer:
                characterObject = GameObject.Instantiate(_playerPrefab, null);
                break;
            case CharacterType.DefaultEnemy:
                characterObject = GameObject.Instantiate(_enemyPrefab, null);
                break;
            default:
                Debug.LogError("Unknown character type: " + characterType);
                break;
        }

        return characterObject;
    }
}
