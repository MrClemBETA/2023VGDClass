using Cinemachine;
using SOS.AndrewsAdventure.Character;
using SOS.AndrewsAdventure.Character.Party;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class BattleManager : MonoBehaviour
{
    /// AM = Attack Multiplier, the amount of damage a character's attack is mutiplied by
    /// BA = Bonus Attack, additional damage that isn't affected by the damage calculation
    /// DD = Defense Divider, the value an attack's total damage is divided by
    /// BD = Bonus Defense, additional defense that isn't affected by the defense divider 
    [SerializeField] int enemiesInBattle;
    [SerializeField] int enemySpeed;
    public static float partySpeed;
    public bool isStunned;
    public Transform characterLocation;
    public Transform character;
    public PlayerController walkSpeed;
    private Party party; 
    public static bool inBattle;
    public Health health;
    private new Renderer renderer;
    public static bool characterChosen;
    public bool alreadyChosen = false;
    public static int actionsMade = 0;
    public static bool isPlayerTurn;
    static bool battleStart = false;
    void startBattle()
    {
        if (partySpeed > enemySpeed)
        {
            isPlayerTurn = true;
            print("You go first!");
            battleStart = true;
        }
        else if (enemySpeed > partySpeed)
        {
            isPlayerTurn = false;
            print("Enemy goes first!");
            battleStart = true;
        }
        else if (enemySpeed == partySpeed)
        {
            print("Equal speed! Coin flip!");
            if (Random.Range(0, 2) == 1)
            {
                isPlayerTurn = true;
                print("You go first!");
                battleStart = true;
            }
            else
            {
                isPlayerTurn = false;
                print("Enemy goes first!");
                battleStart = true;
            }
        }
    }
    void enemyTurn()
    {
        if(isStunned == false)
        {
            if(Random.Range(0,2) == 0) // Attack
            {
                Random.Range(1, 4);
                print("Attack!");
            }
            else // Support
            {
                Random.Range(1, enemiesInBattle + 1);
                print("Support!");
            }
        }
        isPlayerTurn = true;
        
    }
    void battleEnd()
    {
        isPlayerTurn = false;
        battleStart = false;
    }
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        if(walkSpeed != null) 
        { 
            partySpeed = walkSpeed.walkSpeed; 
        }
        
    }
    private void OnMouseDown()
    {
        if(inBattle == true && battleStart == true)
        {
            if (renderer.tag == "Player" && isStunned == true)
            {
                print(renderer.transform.name + " is stunned!");
                alreadyChosen = true;
            }
            if (renderer.tag == "Player" && alreadyChosen == false && isPlayerTurn == true && isStunned == false)
            {
                print(renderer.transform.name);
                characterChosen = true;
                alreadyChosen = true;
            }
            else if (renderer.tag == "Player" && characterChosen == true)
            {
                print("Thanks");
                characterChosen = false;
                alreadyChosen = true;
                actionsMade++;
            }
            if (renderer.tag == "Enemy" && characterChosen == true)
            {
                print("Hit!");
                characterChosen = false;
                actionsMade++;
            }

        }
    }
    private void Update()
    {
        if(characterLocation != null)
        {
            if (character.position == characterLocation.position)
            {
                inBattle = true;
                if (battleStart == false)
                {
                    startBattle();
                }
                else
                {
                    if (isPlayerTurn == false)
                    {
                        enemyTurn();
                    }
                }
                if (actionsMade >= 3)
                {
                    isPlayerTurn = false;
                    alreadyChosen = false;
                    actionsMade = 0;
                }
            }
        }
    }
}
