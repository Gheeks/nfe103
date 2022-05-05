using Assets.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Models.UI
{
    public class ShopUI : MonoBehaviour
    {
        internal Transform container;
        internal Transform shopItemTemplate;
        public List<Item> Items;
        internal float lastUIXPosition = -73000f;
        internal float lastUIYPosition = 52747f;
        internal Item lastBuyItem;
        private List<ShopObserver> observers = new List<ShopObserver>();

        public void BuyItem(Item i)
        {
            lastBuyItem = i;
            NotifyAllObservers();
        }

        public void Subscribe(ShopObserver observer)
        {
            observer.shop = this;
            observers.Add(observer);
        }

        private void NotifyAllObservers()
        {
            foreach (ShopObserver observer in observers)
            {
                observer.update();
            }
        }
    }
}
