using Assets.Models.Common;
using Assets.Models.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Models.Factories
{
    public abstract class EntityFactory : Entity
    {
        public abstract Entity CreateEntity(Type type, Vector3 position, float maxHealth = -1f, float health = -1f, float attackDmg = -1f, float attackSpeed = -1f, float attackTime = -1f, float attackRange = -1f, int armor = -1, float critical = -1f, float movementSpeed = -1f, int exp = -1, int gold = -1);
    }
}
