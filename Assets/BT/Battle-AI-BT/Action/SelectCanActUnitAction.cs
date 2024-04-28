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
    // @Date: 2021-09-28 20:15
    //******************************************
    [Name("ѡ��Ŀ��")]
    [Category("_����/��Ϊ����")]
    [Description("ѡ�����ִ����Ϊ��ս����λ��Ŀ�������ս����λ���Ʒ�Χ�ڣ�����û����cd��")]
    public class SelectCanActUnitAction : ActionTask
    {
        [Name("ս����λ�б�")]
        public BBParameter<List<BattleUnit>> Units;
        [Name("����������ս����λ")]
        public BBParameter<BattleUnit> SelectedUnit;
        [Name("Ŀ�����")]
        public BBParameter<BattleUnit> Target;
        [Name("�������")]
        public BBParameter<float> AttackDuration;

        [Name("��ʼѡ�������")]
        public BBParameter<int> Index;
        private Dictionary<BattleUnit, float> _NextCanAttackTime = new Dictionary<BattleUnit, float>();
        
        /*
        protected override void OnExecute()
        {
            if (Units.value.Count <= 0)
            {
                EndAction(false);
                return;
            }

            var units = Units.value;
            int index = Index.value;
            
            var target = Target.value;

            for (int i = 0; i < units.Count; i++)
            {
                int currentIndex = (i + index) % units.Count;
                var unit = units[currentIndex];
                if (true || _IsValid(unit, target))
                {
                    SelectedUnit.value = unit;
                    EndAction(true);
                    return;
                }
            }

            EndAction(false);
        }

        private bool _IsValid(BattleUnit unit, BattleUnit target)
        {
            var normalAttackData = unit.CreateInfo.NormalAttackDatas[0];
            // if (normalAttackData.Shape.IsPointIn(unit.Transform, target.Transform))
            // {
            //     return _MarkDurationIfTimeout(unit);
            // }
            
            var moveDirAndLength = target.Position - unit.Transform.position;
            float skillDistance = normalAttackData.Shape.MaxDistance();
            float realDistance = moveDirAndLength.magnitude;
            if (skillDistance >= realDistance)
            {
                return _MarkDurationIfTimeout(unit);
            }

            int layerMask = 1 << Constant.MONSTER_LAYER;
            layerMask |=  1 << Constant.OBSTRUCT_LAYER;
            layerMask |=  1 << Constant.PLAYER_LAYER;
            RaycastHit raycastHit;
            
            float needMoveDistance = realDistance - skillDistance;
            if (!Physics.Raycast(unit.Transform.position + Vector3.up * 0.8f, moveDirAndLength.normalized, out raycastHit, needMoveDistance + 0.1f, layerMask))
            {
                return _MarkDurationIfTimeout(unit);
            }

            if (Vector3.Distance(raycastHit.point, unit.Transform.position) >= needMoveDistance)
            {
                return _MarkDurationIfTimeout(unit);
            }

            return false;
        }

        private bool _MarkDurationIfTimeout(BattleUnit unit)
        {
            if (_NextCanAttackTime.ContainsKey(unit))
            {
                if (Time.time < _NextCanAttackTime[unit])
                {
                    return false;
                }

                _NextCanAttackTime[unit] = Time.time + AttackDuration.value;
                return true;
            }
            
            _NextCanAttackTime.Add(unit, Time.time + AttackDuration.value);
            return true;
        }
        */
    }
}