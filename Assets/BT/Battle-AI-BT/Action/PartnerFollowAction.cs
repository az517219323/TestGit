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
    // @Date: 2021-09-02 20:25
    //******************************************
    [Name("������")]
    [Category("_����/��Ϊ����")]
    [Description("������")]
    public class PartnerFollowAction : ActionTask
    {
        [Name("��Ҷ���")]
        public BBParameter<BattleUnit> Player;
        [Name("������")]
        public BBParameter<BattleUnit> Partner;
        [Name("�������")]
        public BBParameter<int> PartnerIndex;
        [Name("���;���")]
        public BBParameter<float> TransferDistance;
        [Name("��ʼ�������")]
        public BBParameter<float> StartFollowDistance;
        [Name("ֹͣ�������")]
        public BBParameter<float> StopFollowDistance;
        [Name("�����������")]
        public BBParameter<float> FollowPositionCalculateDuration;

        private Vector3 _Position;
        private Vector3 _MoveDir;
        private Quaternion _Rotation;
        private BattleUnit _Partner;
        private float _NextCalculateTime = -1;
        private bool _Following;

        /*
        protected override void OnExecute()
        {
            _NextCalculateTime = -1;
            _Partner = Partner.value;
            _Following = false;
        }

        private void _Recaculate(bool force = false)
        {
            if (Time.time < _NextCalculateTime && !force)
            {
                return;
            }

            _NextCalculateTime = Time.time + FollowPositionCalculateDuration.value;

            Vector3 position;
            Quaternion rotation;
            UnitService.CalculatePartnerPositionAndRotation(Player.value, PartnerIndex.value, out position, out rotation);
            _Position = position;
            _Rotation = rotation;
            _MoveDir = (_Position - Partner.value.Position).normalized;
        }

        protected override void OnUpdate()
        {
            //Debug.LogError(GetType().FullName + " -- " + Player.value + " : " + Partner.value + ", " + ownerSystemAgent.gameObject);
            float distance = Vector3.Distance(Player.value.Position, Partner.value.Position);
            if (distance >= TransferDistance.value)
            {
                _Recaculate(true);
                var moveComponent = Partner.value.MoveCom;
                moveComponent.SetPosition(_Position);
                moveComponent.SetForward(_Rotation * Vector3.forward);
                _End(true);
                return;
            }

            if (distance >= StartFollowDistance.value)
            {
                _Following = true;
            }

            if (!_Following)
            {
                _End(true);
                return;
            }
            
            _Recaculate();
            if (_CheckEnd())
            {
                _End(true);
                return;
            }

            _Follow();
            
            if (_CheckEnd())
            {
                _End(true);
                return;
            }
            EndAction(true);
        }

        private void _End(bool finish)
        {
            EndAction(finish);
            if (finish)
            {
                _OnMoveEnd(true);    
            }
        }

        private void _Follow()
        {
            _Partner.MoveCom.MoveInWorld(_MoveDir, MoveComponent.STATUS_RUN, null);
            _Partner.GetComponent<FsmComponent>().TryChangeState(UnitStateDefine.Run);
        }

        private void _OnMoveEnd(bool obj)
        {
            _Partner.GetComponent<FsmComponent>().TryChangeToNewState(UnitStateDefine.Idle);
        }

        private bool _CheckEnd()
        {
            return Vector3.Distance(Player.value.Position, Partner.value.Position) <= StopFollowDistance.value;
        }
        */
    }
}