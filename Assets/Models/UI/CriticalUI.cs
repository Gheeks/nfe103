using UnityEngine;
using UnityEngine.UI;

namespace Assets.Models.UI
{
    public class CriticalUI : StatsUI
    {
        public CriticalUI()
        {
            this.go = GameObject.Instantiate(this.GetClassGameObject());
            go.transform.parent = this.mainClass.transform.Find("GeneratedUI").gameObject.transform;
            go.SetActive(true);
            go.GetComponent<RectTransform>().localPosition = Vector3.zero;
            text = go.transform.GetComponentInChildren<Text>();
        }
        public override void update()
        {
            text.text = player.stats.attackCrit.ToString();
        }
    }
}
