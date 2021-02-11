using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NPCBehaviorEngine
{
    public interface INPCBase
    {
        void Initialize();

        void OnEnter();

        void OnExit();

    }
}
