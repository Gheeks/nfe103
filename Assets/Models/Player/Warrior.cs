using Assets.Models.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Models.Player
{
    public class Warrior : Player
    {
        public Warrior(float maxHealth, float health, float attackDmg, float attackSpeed, float attackTime, float attackRange, int armor, float critical, float movementSpeed, int exp, int gold)
        {
            this.go = GameObject.Instantiate(this.GetClassGameObject());
            this.SetStats(go);
            this.stats.maxHealth = maxHealth;
            this.stats.health = health;
            this.stats.attackDmg = attackDmg;
            this.stats.attackSpeed = attackSpeed;
            this.stats.attackTime = attackTime;
            this.stats.attackRange = attackRange;
            this.stats.armor = armor;
            this.stats.attackCrit = critical;
            this.stats.movementSpeed = movementSpeed;
            this.stats.exp = exp;
            this.stats.gold = gold;

            this.SetSlider(go);
            this.slider.maxValue = maxHealth;
            this.slider.value = health;

            go.transform.position = new Vector3(-7f, 0, -48f);
            go.SetActive(true);
        }
    }
}