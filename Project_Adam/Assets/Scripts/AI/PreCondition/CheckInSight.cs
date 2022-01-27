using UnityEngine;
namespace AI
{
    public class CheckInSight : PreConditionNode
    {
        public Transform target;
        public float detectDis;
        public CheckInSight(Transform target,float dis) : base() 
        { 
            this.target = target;
            this.detectDis = dis;
        }

        public override void Init(AITree tree)
        {
            base.Init(tree);
        }
        public override bool Check()
        {
            var trans = tree.trans;
            var dis=Vector3.Distance(trans.position, target.position);
            return(dis<=detectDis); ;
        }
    }
}
