using Assets.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Models.UI
{
    public class WaveUI : StatsUI
    {
        public WaveUI()
        {
            this.go = GameObject.Instantiate(this.GetClassGameObject());
            go.transform.parent = this.mainClass.transform.Find("GeneratedUI").gameObject.transform;
            go.SetActive(true);
            go.GetComponent<RectTransform>().localPosition = Vector3.zero;
            text = go.transform.GetComponentInChildren<Text>();
            text.text = 1.ToString();
        }
        public override void update()
        {
        }
    }
}
