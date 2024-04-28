using System.Collections.Generic;
using DefaultNamespace;
using KLFramework.IOC;
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
    // @Date: 2021-08-04 17:12
    //******************************************
    [Name("����Ŀ��")]
    [Category("_����/��Ϊ����")]
    [Description("�״λ���CDʱ�䵽�����سɹ������򷵻�ʧ��")]
    public class UnitFindTargetAction : ActionTask
    {
        [Name("�������key")]
        public BBParameter<string> TeamKey;
        [Name("����Ŀ���б�")]
        public BBParameter<List<BattleUnit>> Units;
        [Name("��ʼ�����б�����")]
        public BBParameter<int> Index;
        [Name("������")]
        public BBParameter<IBeanContext> BeanContext;
        [Name("ս����λ")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("Ŀ�����")]
        public BBParameter<BattleUnit> TargetBattleUnit;
        
        /*
        private Dictionary<BattleUnit, FindTargetRecord> _TargetRecords = new Dictionary<BattleUnit, FindTargetRecord>();

        class FindTargetRecord
        {
            public BattleUnit LastTarget;

            public FindTargetRecord(BattleUnit target)
            {
                LastTarget = target;
            }

            public bool IsNeedFindTarget()
            {
                return LastTarget == null || LastTarget.IsDead();
            }
        }
        
        protected override void OnExecute()
        {
            var battleUnit = BattleUnit.value = Units.value[Index.value % Units.value.Count];
            BattleUnit target;
            if (_TargetRecords.ContainsKey(battleUnit))
            {
                if (_TargetRecords[battleUnit].IsNeedFindTarget())
                {
                    target = _FindNewTarget();
                    _TargetRecords[battleUnit].LastTarget = target;
                }
                else
                {
                    target = _TargetRecords[battleUnit].LastTarget;
                }
            }
            else
            {
                target = _FindNewTarget();
                _TargetRecords.Add(battleUnit, new FindTargetRecord(target));
            }

            TargetBattleUnit.value = target;
            EndAction(true);
        }

        private BattleUnit _FindNewTarget()
        {
            var teamAIService = BeanContext.value.FindObjectOfType<TeamAIService>();
            return teamAIService.Random(TeamKey.value);
        }
        */
    }
}