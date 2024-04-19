using SOS.AndrewsAdventure.Character.Party;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOS.AndrewsAdventure.Character
{
    public class Enemy : Character
    {
        [SerializeField] int level = 1;

        public override int GetData(string att)
        {
            return attributes.GetAttribute(att).GetData(level);
        }
    }
}