using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    public class ParallelORNode : BaseNode
    {
        public ParallelORNode(PreConditionNode preCondition) : base(preCondition) { }
        protected override bool DoEvaluate()
        {
            if(Help.IsCollectionEmpty(children))return false;
            bool flag = false;
            foreach(var child in children)
            {
                if (child.Evaluate())
                {
                    flag = true;
                    break; 
                }
            }
            return flag;
        }
        protected override TickResult DoTick()
        {
            TickResult result = TickResult.Running;
            foreach(var child in children)
            {
                if (child.Evaluate())
                {
                   var temp= child.Tick();
                    if (temp == TickResult.Running)
                    {
                        result = temp;
                    }
                }
            }
            if(result == TickResult.Ended)
            {
                Clear();
            }
            return result;
        }
        public override void Clear()
        {
            base.Clear();
            foreach(var child in children)
            {
                child.Clear();
            }
        }
    }
}
