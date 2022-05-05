using Assets.Models.Common;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Models.UI
{
    public class InventoryUI : StatsUI
    {
        List<Image> imageList;

        public InventoryUI(){
            imageList = new List<Image>();
            this.mainClass = this.mainClass.transform.Find("Inventory System UI").gameObject;
            for (int i = 1; i < 7; i++)
            {
                imageList.Add(this.mainClass.transform.Find("SlotItem"+i+"Img").GetComponent<Image>());
            }
            
        }

        public override void update()
        {
            for (int index = 0; index < player.inventory.Count; index++)
            {
                imageList[index].sprite = player.inventory[index].Sprite;
                imageList[index].color = Color.white;
            }
        }
    }
}
