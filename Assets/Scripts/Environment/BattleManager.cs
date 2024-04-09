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
    [SerializeField] Transform andrewBattleLocation;
    public Transform Andrew;
    public Camera BattleCamera;
    private Party party; 
    public static bool inBattle;
    public Health health;
    public Transform chosenCharacter;
    public Transform chosenEnemy;
    private new Renderer renderer;
    public static bool characterChosen;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    private void OnMouseDown()
    {
        if (inBattle == true)
        {
            if (renderer.tag == "Player")
            {
                print(renderer.transform.name);
                characterChosen = true;

            }
            if (renderer.tag == "Enemy" && characterChosen == true)
            {
                print("Hit!");
                characterChosen = false;
            }
        }

    }
    void Awake()
    {

    }
    private void Update()
    {
        if(Andrew.position == andrewBattleLocation.position)
        {
            inBattle = true;
        }
    }
}
