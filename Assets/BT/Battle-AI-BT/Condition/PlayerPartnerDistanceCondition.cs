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
    [Name("��Һͻ������ж�")]
    [Category("_����/��������")]
    [Description("�ж���Һͻ��֮��ľ����Ƿ���������")]
    public class PlayerPartnerDistanceCondition : ConditionTask
    {
        [Name("��Ҷ���")]
        public BBParameter<BattleUnit> Player;
        [Name("������")]
        public BBParameter<BattleUnit> Partner;
        [Name("�ȽϾ���")]
        public BBParameter<float> Distance;
        [Name("�ȽϷ�ʽ")]
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