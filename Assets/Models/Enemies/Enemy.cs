using Assets.Models.Common;
using Assets.Models.Enemies.Classes;
using Assets.Models.Factories;
using System;
using System.Timers;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Models.Enemies
{
    public class Enemy : EntityFactory
    {
        public NavMeshAgent agent;
        public BoxCollider ColliderEnemy;
        public Rigidbody RigidBodyEnemy;

        public IEnemyBuilder builder;
        public EnemyAttack enemyAttack;
        public EnemyFollow enemyFollow;
        public bool isOnCd = false;
        public Timer cdTime;

        public Enemy()
        {
            this.mainClass = GameObject.Find("Enemies");
            cdTime = new Timer();
        }

        public override Entity CreateEntity(Type type, Vector3 position, float maxHealth = -1f, float health = -1f, float attackDmg = -1f, float attackSpeed = -1f, float attackTime = -1f, float attackRange = -1f, int armor = -1, float critical = -1f, float movementSpeed = -1f, int exp = -1, int gold = -1)
        {
            Debug.Log(this);
            switch (type.FullName)
            {
                case "Assets.Models.Enemies.Classes.Bowman":
                    Bowman b = (Bowman)Activator.CreateInstance(type);
                    b.SetStatsNewInstance(maxHealth, health, attackDmg, attackSpeed, attackTime, attackRange, armor, critical, movementSpeed, exp, gold, position);
                    return b;
                case "Assets.Models.Enemies.Classes.Mage":
                    Mage m = (Mage)Activator.CreateInstance(type);
                    m.SetStatsNewInstance(maxHealth, health, attackDmg, attackSpeed, attackTime, attackRange, armor, critical, movementSpeed, exp, gold, position);
                    return m;
                case "Assets.Models.Enemies.Classes.Spearman":
                    Spearman s = (Spearman)Activator.CreateInstance(type);
                    s.SetStatsNewInstance(maxHealth, health, attackDmg, attackSpeed, attackTime, attackRange, armor, critical, movementSpeed, exp, gold, position);
                    return s;
                case "Assets.Models.Enemies.Classes.Soldier":
                    Soldier sol = (Soldier)Activator.CreateInstance(type);
                    sol.SetStatsNewInstance(maxHealth, health, attackDmg, attackSpeed, attackTime, attackRange, armor, critical, movementSpeed, exp, gold, position);
                    return sol;
            }
            return null;
        }

        public void SetActive()
        {
            go.SetActive(true);
            state = EntityState.Alive;
        }

        public void Disactive()
        {
            go.SetActive(true);
            state = EntityState.Idle;
        }
    }
}