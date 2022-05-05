using Assets.Models.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Models.Common
{
    public class FollowPlayer : IFollowStrategy
    {
        public void Follow(Enemy e, GameObject go)
        {
            Vector3 vector3 = go.transform.position;
            vector3.z -= 0.7f;
            vector3.y -= 0.7f;
            e.agent.speed = e.stats.movementSpeed;
            e.agent.SetDestination(vector3);
            Vector3 lookVector = go.transform.position - e.go.transform.position;
            lookVector.y = go.transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            e.go.transform.rotation = Quaternion.Slerp(e.go.transform.rotation, rot, 1);
        }
    }
}
