using Cinemachine;
using SOS.AndrewsAdventure.Character;
using SOS.AndrewsAdventure.Character.Party;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BattleManager : MonoBehaviour
{
    /// AM = Attack Multiplier, the amount of damage a character's attack is mutiplied by
    /// BA = Bonus Attack, additional damage that isn't affected by the damage calculation
    /// DD = Defense Divider, the value an attack's total damage is divided by
    /// BD = Bonus Defense, additional defense that isn't affected by the defense divider 
    [SerializeField] string characterName;
    [SerializeField] int enemiesInBattle;
    public Transform characterLocation;
    public Transform character;
    public Camera BattleCamera;
    private Party party; 
    public static bool inBattle;
    public Health health;
    private new Renderer renderer;
    public static bool characterChosen;
    public bool alreadyChosen = false;
    public int actionsMade = 0;
    public bool playerTurn = true;
    
    void enemyTurn()
    {
        for(int i = 0; i < enemiesInBattle; i++)
        {

        }
    }
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    private void OnMouseDown()
    {
        if (inBattle == true)
        {
            if (renderer.tag == "Player" && alreadyChosen == false && playerTurn == true)
            {
                print(renderer.transform.name);
                characterChosen = true;
                alreadyChosen = true;
            }
            else if(renderer.tag == "Player" && characterChosen == true) 
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
            if(playerTurn == false)
            {
                
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
                if (actionsMade >= 3)
                {
                    playerTurn = false;
                }
            }
        }
    }
}
