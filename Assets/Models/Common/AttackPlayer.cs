using Assets.Models.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Models.Common
{
    public class AttackPlayer
    {
/*        public void Attack(Enemy enemy)
        {
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
        public void Attack(Enemy enemy, IAttackStrategy strategy)
        {
            throw new NotImplementedException();
        }*/
    }
}
