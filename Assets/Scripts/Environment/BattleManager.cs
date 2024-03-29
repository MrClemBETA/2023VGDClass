using Cinemachine;
using SOS.AndrewsAdventure.Character;
using SOS.AndrewsAdventure.Character.Party;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    /// AM = Attack Multiplier, the amount of damage a character's attack is mutiplied by
    /// BA = Bonus Attack, additional damage that isn't affected by the damage calculation
    /// DD = Defense Divider, the value an attack's total damage is divided by
    /// BD = Bonus Defense, additional defense that isn't affected by the defense divider 
    [SerializeField] string characterName;
    public Camera BattleCamera;
    private Party party; 
    public EnemyManager inBattle;
    public Health health;
    public Transform chosenCharacter;
    public Transform chosenEnemy;

    private void Start()
    {
        BattleCamera = Camera.main;
    }
    void Awake()
    {

    }
    void OnButtonDown()
    {

    }


    private void Update()
    {

    }
}
