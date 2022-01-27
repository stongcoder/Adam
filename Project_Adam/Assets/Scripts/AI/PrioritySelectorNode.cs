using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class PrioritySelectorNode:BaseNode
    {
        private BaseNode activeNode;
        protected override bool DoEvaluate()
        {
            bool flag = false;
            foreach(var child in children)
            {
                if (child.Evaluate())
                {
                    flag = true;
                    activeNode = child;
                    break;
                }
            }
            return flag;
        }
        protected override TickResult DoTick()
        {
            if (activeNode == null) return TickResult.Ended;
            TickResult result = activeNode.Tick();
            return result;

        }
    }
}
