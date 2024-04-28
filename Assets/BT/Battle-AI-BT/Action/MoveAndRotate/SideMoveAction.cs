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
    [Name("�����ƶ�")]
    [Category("_����/��Ϊ����/�ƶ���ת��")]
    [Description("ս����λ�����Ŀ�굥λ�����ƶ�")]
    public class SideMoveAction : ActionTask
    {
        [Name("�����Сʱ��")]
        public BBParameter<float> MinMoveTime;
        [Name("������ʱ��")]
        public BBParameter<float> MaxMoveTime;
        [Name("ս����λ")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("Ŀ�����")]
        public BBParameter<BattleUnit> TargetBattleUnit;
        
        private int _Direction = 1;
        private float _Time = 0;
        private float _MoveTime;

        /*
        protected override void OnExecute()
        {
            _MoveTime = Random.Range(MinMoveTime.value, MaxMoveTime.value);
            _Time = 0;
            _Direction = Random.Range(0, 1f) < 0.5f ? -1 : 1;
        }
        
        protected override void OnUpdate()
        {
            
            _Time += Time.deltaTime;
        
            BattleUnit unit = BattleUnit.value;//blackboard.GetVariable<BattleUnit>("BattleUnit").value;
            BattleUnit target = TargetBattleUnit.value;//blackboard.GetVariable<BattleUnit>("TargetBattleUnit").value;
            
            var selfMoveComponent = unit.GetComponent<MoveComponent>();
            Vector3 moveDir = Vector3.Lerp(new Vector3(_Direction, 0, 0), new Vector3(0, 0, 1), 0.25f).normalized;
            selfMoveComponent.Move(moveDir, MoveComponent.STATUS_RUN, _OnMoveEnd, target, Constant.SIDE_WALK_SPEED);
            unit.GetComponent<FsmComponent>().TryChangeState(UnitStateDefine.Walk, _Direction);
            bool end = _Time >= _MoveTime;
            
            if (end)
            {
                selfMoveComponent.Update(Time.time, Time.deltaTime);
                selfMoveComponent.StopMove();
                EndAction(true);
            }
        }
        
        private void _OnMoveEnd(bool obj)
        {
        }
        */
    }
}