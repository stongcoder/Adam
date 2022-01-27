using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    public class PlayAnim : ActionNode
    {
        private Color col;

        private Color oriCol;
        private MeshRenderer mr;
        public PlayAnim(PreConditionNode precondition,Color col):base(precondition)
        {
            this.col = col;
        }
        protected override void Enter()
        {
            base.Enter();
            mr = tree.trans.GetComponent<MeshRenderer>();
            oriCol = mr.material.color;
            mr.material.color = col;
        }
        protected override void Exit()
        {
            base.Exit();
            if(mr != null)
            {
                mr.material.color=oriCol;
            }
        }
    }

}
