using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Models.Common
{
    public abstract class Entity : MonoBehaviour
    {
        public GameObject mainClass { get; set; }
        internal GameObject go { get; set; }
        public Stats stats { get; set; }
        public Slider slider { get; set; }
        public EntityState state = EntityState.Idle;

        public GameObject GetClassGameObject()
        {
            return mainClass.transform.Find(this.GetType().Name).gameObject;
        }

        public void SetStats(GameObject go)
        {
            stats = go.GetComponent<Stats>();
        }

        public void SetSlider(GameObject go)
        {
            slider = go.GetComponentInChildren<Slider>();
        }
    }
}
