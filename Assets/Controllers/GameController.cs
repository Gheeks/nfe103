using Assets.Models.Common;
using Assets.Models.Enemies;
using Assets.Models.Player;
using Assets.Models.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Controllers
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }
        public MainUIController MainUIController;
        public WaveController WaveController;
        public ShopController ShopController;
        public PlayerController PlayerController;
        public EnemyController EnemyController;
        public Player player;
        public Nexus Nexus;

        void Start()
        {
            Instance = this;
            // Initiate UI first
            MainUIController = new MainUIController();
            MainUIController.CreateStatsUI();
            MainUIController.CreateNexusUI(SettingsController.NexusHP);
            Nexus = new Nexus(SettingsController.NexusHP);
            MainUIController.SubscribeUIToNexus(Nexus);

            ShopController = new ShopController();
            ShopUI s = ShopController.CreateGlobalShop();
            ShopController.CreateItemButton(new Item("Rebedon", 3200, "Pour taper mieux", Resources.Load<Sprite>("ShopIMG/Rabadon_s_Deathcrown_item"), _damages: 120));
            ShopController.CreateItemButton(new Item("Godasses", 300, "Pour courir vite", Resources.Load<Sprite>("ShopIMG/Boots_of_Speed_item"), _movementSpeed: 5));
            ShopController.CreateItemButton(new Item("Kotkipik", 2300, "Elle ne renvoie pas les dégats", Resources.Load<Sprite>("ShopIMG/Bramble_Vest_item"), _armor: 20));
            ShopController.CreateItemButton(new Item("Li yan dri", 3200, "Rabadon first item", Resources.Load<Sprite>("ShopIMG/Liandry_s_Torment_item"), _damages: 20));
            ShopController.CreateItemButton(new Item("Flux de loden", 3300, "Pour un objet hors méta", Resources.Load<Sprite>("ShopIMG/Luden_s_Echo_item"), _damages: 25));
            ShopController.CreateItemButton(new Item("Popo", 150, "Peut-être qu'elle vous donnera de la vie", Resources.Load<Sprite>("ShopIMG/Health_Potion_item"), _health: 20));

            //Create entities
            player = new Assets.Models.Player.Mage(100, 100, 100, 1, 1, 2, 10, 1, 3, 0, 50);
            PlayerController = new PlayerController(player, s);

            EnemyController = new EnemyController();

            // Waves to play
            WaveController = new WaveController();
            WaveController.CreateWave(EnemyController.CreateEnemiesForWave(SettingsController.EnemyPerWaves));
            EnemyController.ActiveAllEnemyForWave(GetEnnemiesOfCurrentWave());

            MainUIController.SubscribeToPlayer(player);
            player.NotifyAllObservers();

            PlayerController.MakePlayerActive();
            PlayerController.MakeFocusOnCamera();
        }

        void Update()
        {
            if (Nexus.stats.health <= 0)
            {
                MakeEndGame(WaveController.WaveNumer);
            }
            else
            {
                EnemyController.MoveEnemies(GetEnnemiesOfCurrentWave());
                EnemyController.MakeEnnemyAttack(GetEnnemiesOfCurrentWave());
                if (GetEnnemiesOfCurrentWave().Count == 0)
                {
                    SettingsController.EnemyPerWaves++;
                    WaveController.CreateWave(EnemyController.CreateEnemiesForWave(SettingsController.EnemyPerWaves));
                    MainUIController.WaveUI.text.text = WaveController.WaveNumer.ToString();
                    EnemyController.BuffEnemies(GetEnnemiesOfCurrentWave(), WaveController.WaveNumer);
                    EnemyController.ActiveAllEnemyForWave(GetEnnemiesOfCurrentWave());
                }
                PlayerController.RevivePlayer();
            }
        }

        public List<Enemy> GetEnnemiesOfCurrentWave()
        {
            return WaveController.Waves.Last().enemies.Where((e) => e.state == EntityState.Alive || e.state == EntityState.Idle).ToList();
        }

        public Enemy GetEnemyGo(GameObject go)
        {
            return GetEnnemiesOfCurrentWave().Find((e) => e.go == go);
        }

        public void MakeEndGame(int waves)
        {
            GameObject endgo = GameObject.Find("UI").gameObject.transform.Find("Endbackground").GetComponent<Image>().gameObject;
            endgo.SetActive(true);
            endgo.transform.Find("VagueTxt").GetComponent<Text>().text = waves.ToString();
        }
    }
}
