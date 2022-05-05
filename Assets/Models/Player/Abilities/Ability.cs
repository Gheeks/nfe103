using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Models.Player.Abilities {
    public class Ability
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Cooldown { get; set; }
        public Ability() { }
    }
}
