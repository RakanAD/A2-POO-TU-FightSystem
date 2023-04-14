
using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Défintion simple d'un équipement apportant des boost de stats
    /// </summary>
    public class Equipment
    {
        [SerializeField]int _bonusHealth;
        [SerializeField]int _bonusAttack;
        [SerializeField]int _bonusDefense;
        [SerializeField]int _bonusSpeed;
        public Equipment(int bonusHealth, int bonusAttack, int bonusDefense, int bonusSpeed)
        {
            _bonusHealth = bonusHealth;
            _bonusAttack = bonusAttack;
            _bonusDefense = bonusDefense;
            _bonusSpeed = bonusSpeed;

           
        }

        public int BonusHealth { get => _bonusHealth; protected set => _bonusHealth = 100; }
        public int BonusAttack { get => _bonusAttack; protected set => _bonusAttack = 90; }
        public int BonusDefense { get => _bonusDefense; protected set => _bonusDefense = 70; }
        public int BonusSpeed { get => _bonusSpeed; protected set => _bonusSpeed = 12; }

    }
}
