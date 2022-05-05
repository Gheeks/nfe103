using Assets.Controllers;
using Assets.Models.Common;
using System;
using System.Collections;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;

namespace Assets.Models.Enemies
{
    public class EnemyAttack : MonoBehaviour, IEnemyBuilder
    {
        public Assets.Models.Player.Player playerToAttack;
        public Enemy currentEnemy;
/*        public IAttackStrategy attackStrategy;
*/
        private void OnTriggerEnter(Collider other)
        {
            currentEnemy = GameController.Instance.GetEnemyGo(this.gameObject);
            currentEnemy.enemyAttack.playerToAttack = GameController.Instance.player;
        }

        private void OnTriggerExit(Collider other)
        {
            currentEnemy = GameController.Instance.GetEnemyGo(this.gameObject);
        }

        public void Build(Enemy enemy)
        {
            currentEnemy = enemy;
            enemy.enemyAttack = this;
        }

        public void AttackEnemy(Enemy enemy)
        {
            if (GameController.Instance.player.state == EntityState.Alive) AttackPlayerForEnemyInRange(enemy);
            else if (GameController.Instance.player.state == EntityState.Dead) AttackNexus(enemy);
        }

        private void AttackNexus(Enemy enemy)
        {
            currentEnemy = enemy;
            if (!currentEnemy.cdTime.Enabled)
            {
                currentEnemy.cdTime.Interval = enemy.stats.attackTime * 1000;
                currentEnemy.cdTime.Elapsed += delegate { Timer_Elapsed_Nexus(enemy); };
            }

            if (!currentEnemy.isOnCd)
            {
                Vector3 Vector3 = new Vector3(-4, 0, -59);
                if (Vector3.Distance(currentEnemy.ColliderEnemy.ClosestPoint(Vector3), Vector3) < 2)
                {
                    GameController.Instance.Nexus.stats.health -= 5;
                    GameController.Instance.Nexus.NotifyAllObservers();
                    currentEnemy.isOnCd = true;
                    currentEnemy.cdTime.Start();
                }
            }
        }

        public void AttackPlayerForEnemyInRange(Enemy enemy)
        {
            currentEnemy = enemy;
            playerToAttack = enemy.enemyAttack.playerToAttack;
            if (!enemy.cdTime.Enabled)
            {
                enemy.cdTime.Interval = enemy.stats.attackTime * 1000;
                enemy.cdTime.Elapsed += delegate { Timer_Elapsed(enemy, playerToAttack); };
            }

            if (!enemy.isOnCd && enemy.enemyAttack.playerToAttack?.go)
            {
                if (!currentEnemy?.go)
                    currentEnemy = GameController.Instance.GetEnemyGo(this.gameObject);
                else currentEnemy = enemy;

                currentEnemy.enemyAttack.playerToAttack = playerToAttack;
                if (!currentEnemy.isOnCd)
                {
                    if (Vector3.Distance(currentEnemy.ColliderEnemy.ClosestPoint(playerToAttack.go.transform.position), playerToAttack.go.transform.position) < currentEnemy.stats.attackRange)
                    {
                        playerToAttack.stats.health -= currentEnemy.stats.attackDmg;
                        playerToAttack.NotifyAllObservers();
                        if (playerToAttack.stats.health <= 0 && playerToAttack.state != EntityState.Dead)
                        {
                            currentEnemy.enemyAttack.playerToAttack = null;
                            GameController.Instance.PlayerController.AmorceRespawn();
                        }
                        else
                        {
                            playerToAttack.NotifyAllObservers();
                            currentEnemy.isOnCd = true;
                            currentEnemy.cdTime.Start();
                        }
                    }
                    else
                    {
                        currentEnemy.enemyAttack.playerToAttack = null;
                    }
                }
            }
        }

        private static void Timer_Elapsed(Enemy enemy, Assets.Models.Player.Player player)
        {
            enemy.isOnCd = false;
            enemy.enemyAttack.playerToAttack = player;
            enemy.cdTime.Stop();
        }
        private static void Timer_Elapsed_Nexus(Enemy enemy)
        {
            enemy.isOnCd = false;
            enemy.cdTime.Stop();
        }
    }
}
