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
    [Name("创建怪物")]
    [Category("_昆仑/行为任务")]
    [Description("自动创建怪物")]
    public class AICreateUnitAction : ActionTask
    {
        public enum PositionType
        {
            Self,
            Player,
            Scene
        }

        [Name("位置类型")]
        public BBParameter<PositionType> PosType;
        [Name("战斗单位")]
        public BBParameter<BattleUnit> BattleUnit;
        [Name("阵营")]
        public BBParameter<int> Camp;
        [Name("怪物配置ID")]
        public BBParameter<List<int>> ConfigUnitIDs;
        [Name("是否启用AI")]
        public BBParameter<bool> EnableAI = true;
        [Name("行为树名字")]
        public BBParameter<string> TreeName;
        [Name("创建位置范围")]
        public BBParameter<List<BaseUnitCreater.Range>> Ranges;
        [Name("一轮的时间")]
        public BBParameter<float> RoundDuration;
        [Name("一轮的数量")]
        public BBParameter<int> CountPerRound;
        [Name("限制一轮最大生存数量")]
        public BBParameter<bool> LimitLiveMaxPerRound;
        [Name("最大生存数量")]
        public BBParameter<int> MaxLiveCount;
        [Name("最大创建数量")]
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