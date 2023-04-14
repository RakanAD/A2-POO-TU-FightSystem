using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character 
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        [SerializeField] int _baseHealth;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        [SerializeField] int _baseDefense;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType;
        int currentHealth;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;
            currentHealth = _baseHealth;
            
        }
        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth { get => currentHealth; }
        public TYPE BaseType { get => _baseType; private set => _baseType = TYPE.NORMAL; }
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get => _baseHealth;
        }
        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get => _baseAttack; private set => _baseAttack = value;
        }
        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get => _baseDefense; private set => _baseDefense = value;
        }
        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get => _baseSpeed; private set => _baseSpeed = value;
        }
        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        public Equipment CurrentEquipment { get; private set; }
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set; }

        public bool IsAlive = true;


        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s)
        {
            int _totalDamage = s.Power - _baseDefense;
            currentHealth -= _totalDamage;

            switch (s.Status)
            {
                case StatusPotential.BURN:
                    break;
                case StatusPotential.SLEEP:
                    break;
            }

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                IsAlive = false; 
            }
            
        }
        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {            
            if(newEquipment == null )
            {
                throw new ArgumentNullException();
            }
             CurrentEquipment = newEquipment;
             _baseHealth += CurrentEquipment.BonusHealth;
             Attack += CurrentEquipment.BonusAttack;
             Defense += CurrentEquipment.BonusDefense;
             Speed += CurrentEquipment.BonusSpeed;
        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            _baseHealth -= CurrentEquipment.BonusHealth;
            Attack -= CurrentEquipment.BonusAttack;
            Defense -= CurrentEquipment.BonusDefense;
            Speed -= CurrentEquipment.BonusSpeed;
            CurrentEquipment = null;
        }



    }
}
