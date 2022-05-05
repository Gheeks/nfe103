using Assets.Controllers;
using Assets.Models.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Models.Common
{
    public class FollowNexus : IFollowStrategy
    {
        public void Follow(Enemy e, GameObject go)
        {
            Vector3 vector3 = new Vector3(-4,0,-59);
            e.agent.speed = e.stats.movementSpeed;
            e.agent.SetDestination(vector3);
        }
    }
}
