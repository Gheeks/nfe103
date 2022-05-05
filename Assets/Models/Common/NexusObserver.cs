using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Models.Common
{
    public abstract class NexusObserver
    {
        public Nexus nexus;
        public abstract void update();
    }
}
