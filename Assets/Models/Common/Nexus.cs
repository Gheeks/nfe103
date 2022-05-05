using Assets.Models.Common;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Models.Common
{
    public class Nexus : Entity
    {
        public MeshCollider Mesh { get; set; }
        private List<NexusObserver> observers = new List<NexusObserver>();

        public Nexus(float maxHealth)
        {
            mainClass = GameObject.Find("RedSide");
            go = GameObject.Instantiate(GetClassGameObject());
            SetStats(go);
            stats.maxHealth = maxHealth;
            stats.health = maxHealth;

            SetMesh(go);
            go.SetActive(true);
        }

        public void SetMesh(GameObject go)
        {
            Mesh = go.GetComponentInChildren<MeshCollider>();
        }

        public void Subscribe(NexusObserver observer)
        {
            observer.nexus = this;
            observers.Add(observer);
        }

        public void NotifyAllObservers()
        {
            foreach (NexusObserver observer in observers)
            {
                observer.update();
            }
        }
    }
}