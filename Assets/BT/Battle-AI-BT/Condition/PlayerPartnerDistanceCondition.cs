using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace KLGame.OP.Battle.BTAI
{

    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: junhong.cai@kunlun-inc.com
    // @Date: 2021-09-02 14:28
    //******************************************
    [Name("玩家和伙伴距离判断")]
    [Category("_昆仑/条件任务")]
    [Description("判断玩家和伙伴之间的距离是否满足条件")]
    public class PlayerPartnerDistanceCondition : ConditionTask
    {
        [Name("玩家对象")]
        public BBParameter<BattleUnit> Player;
        [Name("伙伴对象")]
        public BBParameter<BattleUnit> Partner;
        [Name("比较距离")]
        public BBParameter<float> Distance;
        [Name("比较方式")]
        public CompareMethod CheckType;
        
        /*
        protected override bool OnCheck() {

            var t = Partner.value.Transform;
            var distance = Vector3.Distance(t.position, Player.value.Transform.position);
            return OperationTools.Compare(distance, Distance.value, CheckType, 0);
        }
        */
    }
}