using Assets.Models.Common;
using Assets.Models.Player.Abilities;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Models.Player
{
    public class Player : Entity
    {
        public List<Assets.Models.Common.Item> inventory;
        public EntityState state;
        private List<PlayerObserver> observers = new List<PlayerObserver>();
        public NavMeshAgent agent;
        public List<Ability> abilities;
        public Timer respawnCd;

        public Player()
        {
            inventory = new List<Assets.Models.Common.Item>();
            mainClass = GameObject.Find("Summoners");
            respawnCd = new Timer();
        }

        public void Subscribe(PlayerObserver observer)
        {
            observer.player = this;
            observers.Add(observer);
        }

        public void NotifyAllObservers()
        {
            foreach (PlayerObserver observer in observers)
            {
                observer.update();
            }
        }

    }
}