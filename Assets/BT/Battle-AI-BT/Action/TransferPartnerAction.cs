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
    [Name("���ͻ��")]
    [Category("_����/��Ϊ����")]
    [Description("���ͻ��")]
    public class TransferPartnerAction : ActionTask
    {
        [Name("��Ҷ���")]
        public BBParameter<BattleUnit> Player;
        [Name("������")]
        public BBParameter<BattleUnit> Partner;
        [Name("�������")]
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