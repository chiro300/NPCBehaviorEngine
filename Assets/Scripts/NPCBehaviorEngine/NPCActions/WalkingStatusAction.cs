using Assets.Scripts.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NPCBehaviorEngine.NPCActions
{
    
    public class WalkingStatusAction : NPCAction
    {

        public WalkingStatus walkingStatus = WalkingStatus.Stop;
        protected Walk walk;

        public override void Initialize()
        {
            walk = gameObject.GetComponent<Walk>();
        }

        public override void ExecuteAction()
        {
            if(walkingStatus == WalkingStatus.Stop)
                walk.walking = false;
            else
                walk.walking = true;
        }
    }
}
