using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    public class SequenceNode : BaseNode
    {
        private int mActiveIndex = -1;
        public SequenceNode(PreConditionNode precondition = null) : base(precondition) { }
        protected override bool DoEvaluate()
        {
            if(Help.IsCollectionEmpty(children))return false;
            if(mActiveIndex == -1)
            {
                return children[0].Evaluate();
            }
            else
            {
                bool result=children[mActiveIndex].Evaluate();
                if (!result)
                {
                    children[mActiveIndex].Clear();
                    mActiveIndex = -1;
                }
                return result;
            }
        }
        protected override TickResult DoTick()
        {
            if (mActiveIndex == -1)
            {
                mActiveIndex = 0;
            }
            var result =children[mActiveIndex].Tick();
            if (result == TickResult.Ended)
            {
                children[mActiveIndex].Clear();
                mActiveIndex++;
                if (mActiveIndex >= children.Count)
                {
                    mActiveIndex = -1;
                }
                else
                {
                    result = TickResult.Running;
                }
            }
            return result;
        }
        public override void Clear()
        {
            base.Clear();
            mActiveIndex = -1;
            foreach(var child in children)
            {
                child.Clear();
            }
        }
    }

}
