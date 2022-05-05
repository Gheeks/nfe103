using Assets.Models.Common;
using Assets.Models.UI;
using System.Collections.Generic;


namespace Assets.Controllers
{
    public class MainUIController
    {
        List<StatsUI> StatsUI = new List<StatsUI>();
        public WaveUI WaveUI;
        NexusUI NexusUI;
        public void CreateStatsUI()
        {
            StatsUI.Add(new ArmorUI());
            StatsUI.Add(new CriticalUI());
            StatsUI.Add(new MovementSpeedUI());
            StatsUI.Add(new AttackDamageUI());
            StatsUI.Add(new GoldUI());
            StatsUI.Add(new LevelUI());
            WaveUI = new WaveUI();
            StatsUI.Add(WaveUI);
            StatsUI.Add(new ExpUI());
            StatsUI.Add(new HealthUI());
            StatsUI.Add(new InventoryUI());
        }

        public void CreateNexusUI(float Hp)
        {
            NexusUI = new NexusUI(Hp);
        }

        public void SubscribeToPlayer(Assets.Models.Player.Player p)
        {
            foreach (StatsUI item in StatsUI)
            {
                item.MakeSubscription(p);
            }
        }

        public void SubscribeUIToNexus(Nexus n)
        {
            NexusUI.MakeSubscription(n);
        }
    }
}