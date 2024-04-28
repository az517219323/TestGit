using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-09-28 17:21
    //******************************************
    [Name("对象排序")]
    [Category("_昆仑/行为任务")]
    [Description("对象排序，从近到远或者从远到近")]
    public class SortUnitByDistanceAction : ActionTask
    {
        [Name("战斗单位列表")]
        public BBParameter<List<BattleUnit>> Units;
        [Name("目标对象")]
        public BBParameter<BattleUnit> Target;
        [Name("是否从近到远")]
        public bool FromNearToFar = true;
        
        /*
        protected override void OnExecute()
        {
            var target = Target.value;
            int dir = FromNearToFar ? 1 : -1;
            Units.value.Sort((u1, u2) =>
            {
                float d1 = Vector3.Distance(u1.Position, target.Position);
                float d2 = Vector3.Distance(u2.Position, target.Position);
                return d1.CompareTo(d2) * dir;
            });
            EndAction(true);
        }
        */
    }
}