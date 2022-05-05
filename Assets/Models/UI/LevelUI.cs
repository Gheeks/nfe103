﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.Models.UI
{
    public class LevelUI : StatsUI
    {
        public LevelUI()
        {
            this.go = GameObject.Instantiate(this.GetClassGameObject());
            go.transform.parent = this.mainClass.transform.Find("GeneratedUI").gameObject.transform;
            go.SetActive(true);
            go.GetComponent<RectTransform>().localPosition = Vector3.zero;
            text = go.transform.GetComponentInChildren<Text>();
        }
        public override void update()
        {
            text.text = player.stats.GetLevelFromExp().ToString();
        }
    }
}
