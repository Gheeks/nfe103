using Assets.Models.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Models.UI
{
    public class NexusUI : NexusObserver
    {
        public GameObject mainClass = GameObject.Find("UI");
        public GameObject go;
        public Slider Slider;
        public NexusUI(float maxHp)
        {
            this.go = GameObject.Instantiate(mainClass.transform.Find(this.GetType().Name).gameObject);
            go.transform.parent = this.mainClass.transform.Find("GeneratedUI").gameObject.transform;
            go.SetActive(true);
            Slider = go.transform.Find("Slider").gameObject.GetComponent<Slider>();
            Slider.maxValue = maxHp;
            Slider.value = maxHp;

        }

        public void MakeSubscription(Nexus n)
        {
            n.Subscribe(this);
        }

        public override void update()
        {
            Slider.value = nexus.stats.health;
        }
    }
}
