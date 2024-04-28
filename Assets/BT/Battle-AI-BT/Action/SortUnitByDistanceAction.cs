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
    [Name("��������")]
    [Category("_����/��Ϊ����")]
    [Description("�������򣬴ӽ���Զ���ߴ�Զ����")]
    public class SortUnitByDistanceAction : ActionTask
    {
        [Name("ս����λ�б�")]
        public BBParameter<List<BattleUnit>> Units;
        [Name("Ŀ�����")]
        public BBParameter<BattleUnit> Target;
        [Name("�Ƿ�ӽ���Զ")]
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