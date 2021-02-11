using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NPCBehaviorEngine.NPCDecisions
{
    public class TestDecision : NPCDecision
    {
        public bool decide = false;

        public override bool ExecuteDecide()
        {
            return decide;
        }
    }
}
