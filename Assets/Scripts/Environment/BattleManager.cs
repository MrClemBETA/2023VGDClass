using Cinemachine;
using SOS.AndrewsAdventure.Character;
using SOS.AndrewsAdventure.Character.Party;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public enum BattleState { start, playerTurn, enemyTurn, won, lost }
public class BattleManager : MonoBehaviour
{
    /// AM = Attack Multiplier, the amount of damage a character's attack is mutiplied by
    /// BA = Bonus Attack, additional damage that isn't affected by the damage calculation
    /// DD = Defense Divider, the value an attack's total damage is divided by
    /// BD = Bonus Defense, additional defense that isn't affected by the defense divider
    public CinemachineVirtualCamera vCamera3rdPerson;
    [SerializeField] Transform battlePlayerLocation;
    [SerializeField] Transform battleEnemiesLocation;
    public EnemyManager inBattle;
    public Health health;
    public Transform chosenCharacter;
    public Transform chosenEnemy;

    void Awake()
    {

    }
    void chooseCharacter()
    {
        if (chosenCharacter.name == "Lateef")
        {

        }
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (inBattle == true)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            vCamera3rdPerson.Priority = 1;
            party.MoveParty(battlePlayerLocation.position);
            transform.position = battleEnemiesLocation.position;
        }
    }
}
