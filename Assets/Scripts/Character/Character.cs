using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace SOS.AndrewsAdventure.Character
{
    [RequireComponent (typeof(Health))]
    public class Character : MonoBehaviour
    {
        [SerializeField] protected AttributeGroup attributes;
        [SerializeField] float partySpeed;
        float takenDamage = 0;

        public virtual int GetData(string att)
        {
            Party.Party party = FindObjectOfType<Party.Party>();
            return attributes.GetAttribute(att).GetData(party.GetLevel());
        }

        public void TakeDamage(Character enemy)
        {
            int baseDamage = GetData("Base Damage");
            int AM = GetData("Attack Multiplier");
            int BA = GetData("Bonus Attack");
            int DD = enemy.GetData("Defense Divider");
            int BD = enemy.GetData("Bonus Defense");

            takenDamage = ((baseDamage * AM)/DD) - BD + BA;
            Mathf.Round(takenDamage);
            if(takenDamage <= 0)
            {
                takenDamage = 1;
            }
        }
    }
}
