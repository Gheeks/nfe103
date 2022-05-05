using Assets.Models.Player;
using Assets.Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class PlayerObserver
{
    public Player player;
    public abstract void update();
}