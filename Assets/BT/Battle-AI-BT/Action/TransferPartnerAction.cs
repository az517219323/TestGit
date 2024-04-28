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
    // @Date: 2021-09-02 14:48
    //******************************************
    [Name("传送伙伴")]
    [Category("_昆仑/行为任务")]
    [Description("传送伙伴")]
    public class TransferPartnerAction : ActionTask
    {
        [Name("玩家对象")]
        public BBParameter<BattleUnit> Player;
        [Name("伙伴对象")]
        public BBParameter<BattleUnit> Partner;
        [Name("伙伴索引")]
        public BBParameter<int> PartnerIndex;

        /*
        protected override void OnExecute()
        {
            Vector3 position;
            Quaternion rotation;
            UnitService.CalculatePartnerPositionAndRotation(Player.value, PartnerIndex.value, out position, out rotation);
            var moveComponent = Partner.value.MoveCom;
            moveComponent.SetPosition(position);
            moveComponent.SetForward(rotation * Vector3.forward);
            EndAction(true);
        }
        */
    }
}