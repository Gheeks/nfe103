using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Models.UI
{
    public class StatsUI : PlayerObserver
    {
        public Text text;
        public Slider slider;
        public GameObject mainClass = GameObject.Find("UI");
        internal GameObject go { get; set; }
        public string Path;

        public void MakeSubscription(Assets.Models.Player.Player p)
        {
            p.Subscribe(this);
        }

        public GameObject GetClassGameObject()
        {
            return this.mainClass.transform.Find(this.GetType().Name).gameObject;
        }

        public override void update()
        {
        }
    }
}
