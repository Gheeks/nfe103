using Assets.Models.Common;
using Assets.Models.Enemies;
using Assets.Models.Factories;
using Assets.Models.Player;
using Assets.Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Controllers
{
    public class EnemyController
    {
        public Enemy Enemy = new Enemy();

        public List<Enemy> CreateEnemiesForWave(int number)
        {
            List<Enemy> enemies = new List<Enemy>();
            var random = new System.Random();
            var assembly = Assembly.GetExecutingAssembly();
            Type type;
            Type[] typelist = assembly.GetTypes().Where((t) => String.Equals(t.Namespace, "Assets.Models.Enemies.Classes", StringComparison.Ordinal)).ToArray();
            for (int i = 0; i < number; i++)
            {
                type = typelist[random.Next(typelist.Length)];
                Enemy generated = (Enemy)Enemy.CreateEntity(type, position: new Vector3(UnityEngine.Random.Range(47, 61), 0, UnityEngine.Random.Range(-44f, -74f)));
                EnemyFollow enemyFollow = new EnemyFollow();
                enemyFollow.Build(generated);
                EnemyAttack enemyAttack = new EnemyAttack();
                enemyAttack.Build(generated);
                enemies.Add(generated);
            }
            return enemies;
        }

        public void ActiveAllEnemyForWave(List<Enemy> enemies)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.SetActive();
            }
        }

        public void MoveEnemies(List<Enemy> enemies)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.state == EntityState.Alive)
                    enemy.enemyFollow.Move(enemy);
            }
        }

        public void MakeEnnemyAttack(List<Enemy> enemies)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.state == EntityState.Alive)
                    enemy.enemyAttack.AttackEnemy(enemy);
            }
        }

        public void BuffEnemies(List<Enemy> enemies, int waveNumber)
        {
            float increment = (waveNumber * 10 / 100) + 1.2f;
            foreach (Enemy enemy in enemies)
            {
                enemy.stats.movementSpeed *= increment;
                enemy.stats.attackDmg *= increment;
                enemy.stats.exp += waveNumber;
                enemy.stats.gold += waveNumber;
            }
        }
        
    }
}
