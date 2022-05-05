using Assets.Models.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Models.Common
{
    public interface IAttackStrategy
    {
        public void Attack(Enemy enemy);
    }
}
