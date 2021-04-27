using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NPCBehaviorEngine
{
    [Serializable]
    public class NPCTransition
    {
        public NPCDecision decision;

        public string toTrue;        
    }
}
