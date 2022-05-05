using Assets.Models.Common;
using Assets.Models.Enemies;
using Assets.Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Controllers
{
    public class WaveController
    {
        public int WaveNumer { get => Waves.Count; }
        public List<Wave> Waves { get; set; }

        public WaveController()
        {
            Waves = new List<Wave>();
        }

        public void CreateWave(List<Enemy> enemies)
        {
            Wave w = new Wave();
            w.enemies = enemies;
            Waves.Add(w);
        }

        public void Kill(GameObject enemy)
        {
            Enemy enemyToKill = Waves.Last().enemies.Find((e) => e.go == enemy);
            enemyToKill.state = EntityState.Dead;
            GameObject.Destroy(enemy);
        }
    }
}