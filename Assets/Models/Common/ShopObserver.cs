using Assets.Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class ShopObserver
{
    public ShopUI shop;
    public abstract void update();
}