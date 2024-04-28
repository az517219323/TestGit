using System;
using System.Collections.Generic;
using System.Linq;
//using KLFramework.IOC;
using KLGame.OP.Battle.UnitCreater;
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
    // @Date: 2021-09-16 18:14
    //******************************************
    [Name("��������")]
    [Category("_����/��Ϊ����")]
    [Description("�Զ���������")]
    public class AICreateUnitAction : ActionTask
    {
        public enum PositionType
        {
            Self,
            Player,
            Scene
        }

        [Name("λ������")]
        public BBParameter<PositionType> PosType;
        [Name("ս����λ")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("��Ӫ")]
        public BBParameter<int> Camp;
        [Name("��������ID")]
        public BBParameter<List<int>> ConfigUnitIDs;
        [Name("�Ƿ�����AI")]
        public BBParameter<bool> EnableAI = true;
        [Name("��Ϊ������")]
        public BBParameter<string> TreeName;
        [Name("����λ�÷�Χ")]
        public BBParameter<List<BaseUnitCreater.Range>> Ranges;
        [Name("һ�ֵ�ʱ��")]
        public BBParameter<float> RoundDuration;
        [Name("һ�ֵ�����")]
        public BBParameter<int> CountPerRound;
        [Name("����һ�������������")]
        public BBParameter<bool> LimitLiveMaxPerRound;
        [Name("�����������")]
        public BBParameter<int> MaxLiveCount;
        [Name("��󴴽�����")]
        public BBParameter<int> MaxCreateCount;

        /*
      private IBattleUnitCreater _BattleUnitCreater; 

      protected override void OnExecute()
      {
          var unitService = BattleUnit.value.GlobalContext.FindObjectOfType<UnitService>();
          Func<Vector3> positionGetter = null;
          switch (PosType.value)
          {
              case PositionType.Self:
                  positionGetter = () => BattleUnit.value.Position;
                  break;
              case PositionType.Scene:
                  positionGetter = () => Vector3.zero;
                  break;
              case PositionType.Player:
                  positionGetter = () => unitService.MainPlayer.Position;
                  break;
              default:
                  Debug.LogError("Unknow position type " + PosType.value);
                  break;
          }

          _BattleUnitCreater = new BaseUnitCreater(
              positionGetter,
              Quaternion.identity,
              unitService,
              Camp.value,
              ConfigUnitIDs.value.ToArray(),
              EnableAI.value,
              Ranges.value.ToArray(),
              RoundDuration.value,
              CountPerRound.value,
              LimitLiveMaxPerRound.value,
              MaxLiveCount.value,
              MaxCreateCount.value
              );

      }


      protected override void OnUpdate()
      {
          if (_BattleUnitCreater.TryCreate(Time.time, Time.deltaTime))
          {
              EndAction(true);
          }
      }*/
    }
}