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
    [Name("查找目标")]
    [Category("_昆仑/行为任务")]
    [Description("首次或者CD时间到，返回成功，否则返回失败")]
    public class UnitFindTargetAction : ActionTask
    {
        [Name("队伍查找key")]
        public BBParameter<string> TeamKey;
        [Name("查找目标列表")]
        public BBParameter<List<BattleUnit>> Units;
        [Name("开始查找列表索引")]
        public BBParameter<int> Index;
        [Name("上下文")]
        public BBParameter<IBeanContext> BeanContext;
        [Name("战斗单位")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("目标对象")]
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