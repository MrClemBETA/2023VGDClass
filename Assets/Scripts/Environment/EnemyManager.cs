using Cinemachine;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace SOS.AndrewsAdventure.Character
{
    public class EnemyManager : MonoBehaviour
    {
        public CinemachineVirtualCamera vCamera3rdPerson;
        [SerializeField] Transform battlePlayerLocation;
        [SerializeField] Transform battleEnemiesLocation;
        [SerializeField] Transform playerLocation;
        [SerializeField] float chaseRange = 10f;
        [SerializeField] float detectRange = 1f;
        public Transform MCB;
        public bool inBattle = false;
        private Party.Party party;
        public NavMeshAgent Boulderdash;

        public void Start()
        {
            detectRange = chaseRange * 1.5f;
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
            if (inBattle == true)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                vCamera3rdPerson.Priority = 1;
                party.MoveParty(battlePlayerLocation.position);
                transform.position = battleEnemiesLocation.position;
            }
        }
    }
}

    