using Assets.Controllers;
using Assets.Models.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Models.Enemies
{
    public class EnemyFollow : IEnemyBuilder
    {
        public Enemy currentEnemy;
        public IFollowStrategy followStrategy;
        public FollowPlayer fPlayer = new FollowPlayer();
        public FollowNexus fNexus = new FollowNexus();

        public void Move(Enemy enemy)
        {
            if (GameController.Instance.player.state == EntityState.Alive)
            {
                fPlayer.Follow(enemy, GameController.Instance.player.go);
            }
            else if (GameController.Instance.player.state == EntityState.Dead)
            {
                fNexus.Follow(enemy, GameController.Instance.Nexus.go);
            }
        }

        public void MoveToPlayer(Enemy enemy)
        {

        }

        public void Build(Enemy enemy)
        {
            currentEnemy = enemy;
            enemy.enemyFollow = this;
        }
    }
}