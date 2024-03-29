using Cinemachine;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace SOS.AndrewsAdventure.Character
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] Transform battlePlayerLocation;
        [SerializeField] Transform battleEnemiesLocation;
        [SerializeField] Transform playerLocation;
        [SerializeField] float detectRange = 0f;
        float chaseRange = 0f;
        public Transform MCB;
        public bool inBattle = false;
        private Party.Party party;
        public NavMeshAgent Boulderdash;

        public void Start()
        {
            chaseRange = detectRange * .5f;
            party = FindAnyObjectByType<Party.Party>();
            Boulderdash = GetComponent<NavMeshAgent>();
        }
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Player")
            {
                inBattle = true;
            }
        }

        public void Update()
        {
            if (inBattle == true)
            {
                party.MoveParty(battlePlayerLocation.position);
                transform.position = battleEnemiesLocation.position;
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            if (Vector3.Distance(playerLocation.position, transform.position) <= detectRange)
            {
                Boulderdash.destination = transform.position;
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).transform.LookAt(MCB);
            }
            if (Vector3.Distance(playerLocation.position, transform.position) <= chaseRange)
            {
                Boulderdash.destination = playerLocation.position;
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(0).transform.LookAt(MCB);
            }
            if (Vector3.Distance(playerLocation.position, transform.position) > detectRange)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }
}

    