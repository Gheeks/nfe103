using UnityEngine;
using UnityEngine.UI;

namespace Assets.Models.UI
{
    public class HealthUI : StatsUI
    {
        public HealthUI()
        {
            this.go = GameObject.Instantiate(this.GetClassGameObject());
            go.transform.parent = this.mainClass.transform.Find("GeneratedUI").gameObject.transform;
            go.SetActive(true);
            go.GetComponent<RectTransform>().localPosition = Vector3.zero;
            go.transform.position = Vector3.zero;
            slider = go.transform.Find("Slider").gameObject.GetComponent<Slider>();
        }
        public override void update()
        {
            slider.maxValue = player.stats.maxHealth;
            slider.value = player.stats.health;
        }
    }
}
