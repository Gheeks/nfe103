using Assets.Models.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Models.Common
{
    public class Wave
    {
        public List<Enemy> enemies;
        public int numberOfEnemies { get => enemies.Count; }

        public Wave()
        {
            enemies = new List<Enemy>();
        }

        public void InsertEnemy(Enemy enemy) 
        {
            enemies.Add(enemy);
        }

        public void InsertEnemies(List<Enemy> _enemies) 
        {
            enemies = _enemies;
        }
    }
}