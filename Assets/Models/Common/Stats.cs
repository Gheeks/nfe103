using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Models.Common
{
    public class Stats : MonoBehaviour
    {
        public float maxHealth;
        public float health;
        public int armor;
        public float attackDmg;
        public float attackRange;
        public float attackSpeed;
        public float attackTime;
        public float attackCrit;
        public float movementSpeed;
        public int exp;
        public int gold;

        private GameObject player;
        public float expValue = 0;
        public Stats(float _maxHealth, float _health, float _attackDmg, float _attackRange, float _attackSpeed, float _attackTime, int _armor, float _attackCrit, float _movementSpeed)
        {
            maxHealth = _maxHealth;
            health = _health;
            attackDmg = _attackDmg;
            attackRange = _attackRange;
            attackSpeed = _attackSpeed;
            attackTime = _attackTime;
            armor = _armor;
            attackCrit = _attackCrit;
            movementSpeed = _movementSpeed;
        }

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
        }

        public int GetLevelFromExp()
        {
            int lvl = 1;
            int e = exp;
            if (exp < 280)
                return lvl;
            else
            {
                e -= 280;
                lvl += (exp % 100);
                if (lvl > 18) return 18;
                else return lvl;
            }
        }
    }
}