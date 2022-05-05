using Assets.Models.Common;
using Assets.Models.Player;
using Assets.Models.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Controllers
{
    public class PlayerController : ShopObserver
    {

        public Player player;
        public Camera Camera { get => GameObject.FindWithTag("MainCamera").GetComponent<Camera>(); }

        public PlayerController(Player p, ShopUI shop)
        {
            shop.Subscribe(this);
            player = p;
        }

        public void MakeFocusOnCamera()
        {
            Camera.GetComponent<CameraFollow>().Summoner = player.go.transform;
        }

        public void MakePlayerActive()
        {
            player.go.SetActive(true);
        }

        public override void update()
        {
            Item item = shop.lastBuyItem;
            AddItemToPlayer(item);
        }

        public void AddItemToPlayer(Item item)
        {
            if (player.inventory.Count < 6 && player.stats.gold >= item.Price)
            {
                player.stats.gold -= item.Price;
                player.stats.armor += item.Armor;
                player.stats.attackCrit += item.CriticalDamage;
                player.stats.attackSpeed += item.AttackSpeed;
                player.stats.movementSpeed += item.MovementSpeed;
                player.stats.maxHealth += item.MaxHealth;
                player.stats.health += item.MaxHealth;
                player.inventory.Add(item);
                player.NotifyAllObservers();
            }
        }

        public void AmorceRespawn()
        {
            player.state = EntityState.Dead;
            player.go.SetActive(false);
            player.respawnCd.Interval = 10000;
            player.respawnCd.Elapsed += delegate { Timer_Elapsed(player); };
            GameObject.Find("UI").gameObject.transform.Find("Deadbackground").GetComponent<Image>().gameObject.SetActive(true);
            player.respawnCd.Start();
        }

        public void RevivePlayer()
        {
            if (player.state == EntityState.Dead && !player.respawnCd.Enabled)
            {
                player.stats.health = player.stats.maxHealth;
                player.go.transform.position = new Vector3(-15f, 0, -59.15f);
                player.state = EntityState.Alive;
                player.go.SetActive(true);
                GameObject.Find("UI").gameObject.transform.Find("Deadbackground").GetComponent<Image>().gameObject.SetActive(false);
                player.NotifyAllObservers();
            }
        }

        private static void Timer_Elapsed(Player p)
        {
            p.respawnCd.Stop();
        }
    }
}
