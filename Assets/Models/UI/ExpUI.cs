using UnityEngine;
using UnityEngine.UI;

namespace Assets.Models.UI
{
    public class ExpUI : StatsUI
    {
        public ExpUI()
        {
            this.go = GameObject.Instantiate(this.GetClassGameObject());
            go.transform.parent = this.mainClass.transform.Find("GeneratedUI").gameObject.transform;
            go.SetActive(true);
            go.GetComponent<RectTransform>().localPosition = Vector3.zero;
            go.transform.position = new Vector3(0, -20f);
            slider = go.transform.Find("Slider").gameObject.GetComponent<Slider>();
        }

        public override void update()
        {
            //Base
            slider.maxValue = 280;
            //Todo
            slider.value = player.stats.exp;
        }
    }
}
