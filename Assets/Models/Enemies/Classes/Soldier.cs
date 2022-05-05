using Assets.Models.Common;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Assets.Models.Enemies.Classes
{
    public class Soldier : Enemy
    {
        public Soldier()
        {
            go = GameObject.Instantiate(GetClassGameObject());
        }

        public Soldier(float maxHealth, float health, float attackDmg, float attackSpeed, float attackTime, float attackRange, int exp, int gold)
        {
            go = GameObject.Instantiate(GetClassGameObject());
            SetStats(go);

            stats.health = health;
            stats.attackDmg = attackDmg;
            stats.attackSpeed = attackSpeed;
            stats.attackTime = attackTime;
            stats.attackRange = attackRange;
            stats.exp = exp;
            stats.gold = gold;

            SetSlider(go);
            slider.maxValue = maxHealth;
            slider.value = health;

            agent = go.GetComponentInChildren<NavMeshAgent>();
            ColliderEnemy = go.GetComponentInChildren<BoxCollider>();
            RigidBodyEnemy = go.GetComponentInChildren<Rigidbody>();

            go.transform.position = new Vector3(Random.Range(47, 61), 0, Random.Range(-44f, -74f));
            go.SetActive(true);
        }

        public new void SetStatsNewInstance(float maxHealth, float health, float attackDmg, float attackSpeed, float attackTime, float attackRange, int armor, float critical, float movementSpeed, int exp, int gold, Vector3 position)
        {
            SetStats(go);

            if (maxHealth == -1)
                stats.maxHealth = 120;
            else
                stats.maxHealth = maxHealth;

            if (health == -1)
                stats.health = 120;
            else
                stats.health = health;

            if (attackDmg == -1)
                stats.attackDmg = 8;
            else
                stats.attackDmg = attackDmg;

            if (attackSpeed == -1)
                stats.attackSpeed = 3;
            else
                stats.attackSpeed = attackSpeed;

            if (attackTime == -1)
                stats.attackTime = 3;
            else
                stats.attackTime = attackTime;

            if (attackRange == -1)
                stats.attackRange = 3;
            else
                stats.attackRange = attackRange;

            if (armor == -1)
                stats.armor = 0;
            else
                stats.armor = armor;

            if (critical == -1)
                stats.attackCrit = 0;
            else
                stats.attackCrit = critical;

            if (movementSpeed == -1)
                stats.movementSpeed = 4;
            else
                stats.movementSpeed = movementSpeed;

            if (exp == -1)
                stats.exp = 11;
            else
                stats.exp = exp;

            if (gold == -1)
                stats.gold = 35;
            else
                stats.gold = gold;

            SetSlider(go);
            slider.maxValue = maxHealth;
            slider.value = health;

            agent = go.GetComponentInChildren<NavMeshAgent>();
            ColliderEnemy = go.GetComponentInChildren<BoxCollider>();
            RigidBodyEnemy = go.GetComponentInChildren<Rigidbody>();
            go.transform.position = position;
        }
    }
}